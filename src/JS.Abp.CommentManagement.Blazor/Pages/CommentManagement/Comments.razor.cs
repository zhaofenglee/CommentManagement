using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using Volo.Abp.BlazoriseUI.Components;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using JS.Abp.CommentManagement.Comments;
using JS.Abp.CommentManagement.Permissions;
using JS.Abp.CommentManagement.Shared;

namespace JS.Abp.CommentManagement.Blazor.Pages.CommentManagement
{
    public partial class Comments
    {
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar {get;} = new PageToolbar();
        private IReadOnlyList<CommentWithUserDto> CommentList { get; set; }
        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; } = string.Empty;
        private int TotalCount { get; set; }
        private bool CanCreateComment { get; set; }
        private bool CanEditComment { get; set; }
        private bool CanDeleteComment { get; set; }
        private CommentCreateDto NewComment { get; set; }
        private Validations NewCommentValidations { get; set; } = new();
        private CommentUpdateDto EditingComment { get; set; }
        private Validations EditingCommentValidations { get; set; } = new();
        private Guid EditingCommentId { get; set; }
        private Modal CreateCommentModal { get; set; } = new();
        private Modal EditCommentModal { get; set; } = new();
        private GetCommentsInput Filter { get; set; }
        private DataGridEntityActionsColumn<CommentWithUserDto> EntityActionsColumn { get; set; } = new();
        protected string SelectedCreateTab = "comment-create-tab";
        protected string SelectedEditTab = "comment-edit-tab";
        
        public Comments()
        {
            NewComment = new CommentCreateDto();
            EditingComment = new CommentUpdateDto();
            Filter = new GetCommentsInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };
            CommentList = new List<CommentWithUserDto>();
        }

        protected override async Task OnInitializedAsync()
        {
            await SetToolbarItemsAsync();
            await SetBreadcrumbItemsAsync();
            await SetPermissionsAsync();
        }

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:Comments"]));
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["ExportToExcel"], async () =>{ await DownloadAsExcelAsync(); }, IconName.Download);
            
            Toolbar.AddButton(L["NewComment"], async () =>
            {
                await OpenCreateCommentModalAsync();
            }, IconName.Add, requiredPolicyName: CommentManagementPermissions.Comments.Create);

            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateComment = await AuthorizationService
                .IsGrantedAsync(CommentManagementPermissions.Comments.Create);
            CanEditComment = await AuthorizationService
                            .IsGrantedAsync(CommentManagementPermissions.Comments.Edit);
            CanDeleteComment = await AuthorizationService
                            .IsGrantedAsync(CommentManagementPermissions.Comments.Delete);
        }

        private async Task GetCommentsAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            var result = await CommentsAppService.GetListAsync(Filter);
            CommentList = result.Items;
            TotalCount = (int)result.TotalCount;
        }

        protected virtual async Task SearchAsync()
        {
            CurrentPage = 1;
            await GetCommentsAsync();
            await InvokeAsync(StateHasChanged);
        }

        private  async Task DownloadAsExcelAsync()
        {
            var token = (await CommentsAppService.GetDownloadTokenAsync()).Token;
            var remoteService = await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("CommentManagement") ??
            await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("Default");
            NavigationManager.NavigateTo($"{remoteService?.BaseUrl.EnsureEndsWith('/') ?? string.Empty}api/comment-management/comments/as-excel-file?DownloadToken={token}&FilterText={Filter.FilterText}", forceLoad: true);
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<CommentWithUserDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetCommentsAsync();
            await InvokeAsync(StateHasChanged);
        }

        private async Task OpenCreateCommentModalAsync()
        {
            NewComment = new CommentCreateDto{
                
                
            };
            await NewCommentValidations.ClearAll();
            await CreateCommentModal.Show();
        }

        private async Task CloseCreateCommentModalAsync()
        {
            NewComment = new CommentCreateDto{
                
                
            };
            await CreateCommentModal.Hide();
        }

        private async Task OpenEditCommentModalAsync(CommentWithUserDto input)
        {
            var comment = await CommentsAppService.GetAsync(input.Id);
            
            EditingCommentId = comment.Id;
            EditingComment = ObjectMapper.Map<CommentDto, CommentUpdateDto>(comment);
            await EditingCommentValidations.ClearAll();
            await EditCommentModal.Show();
        }

        private async Task DeleteCommentAsync(CommentWithUserDto input)
        {
            await CommentsAppService.DeleteAsync(input.Id);
            await GetCommentsAsync();
        }

        private async Task CreateCommentAsync()
        {
            try
            {
                if (await NewCommentValidations.ValidateAll() == false)
                {
                    return;
                }

                await CommentsAppService.CreateAsync(NewComment);
                await GetCommentsAsync();
                await CloseCreateCommentModalAsync();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        private async Task CloseEditCommentModalAsync()
        {
            await EditCommentModal.Hide();
        }

        private async Task UpdateCommentAsync()
        {
            try
            {
                if (await EditingCommentValidations.ValidateAll() == false)
                {
                    return;
                }

                await CommentsAppService.UpdateAsync(EditingCommentId, EditingComment);
                await GetCommentsAsync();
                await EditCommentModal.Hide();                
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        private void OnSelectedCreateTabChanged(string name)
        {
            SelectedCreateTab = name;
        }

        private void OnSelectedEditTabChanged(string name)
        {
            SelectedEditTab = name;
        }
        

    }
}
