using JS.Abp.CommentManagement.Permissions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using JS.Abp.CommentManagement.Localization;
using Volo.Abp.UI.Navigation;

namespace JS.Abp.CommentManagement.Blazor.Menus;

public class CommentManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }

        var moduleMenu = AddModuleMenuItem(context);
        AddMenuItemComments(context, moduleMenu);
    }

    private static async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        var l = context.GetLocalizer<CommentManagementResource>();

        //context.Menu.AddItem(new ApplicationMenuItem(CommentManagementMenus.Prefix, displayName: "Sample Page", "/CommentManagement", icon: "fa fa-globe"));

        await Task.CompletedTask;
    }
    private static ApplicationMenuItem AddModuleMenuItem(MenuConfigurationContext context)
    {
        var moduleMenu = new ApplicationMenuItem(
            CommentManagementMenus.Prefix,
            context.GetLocalizer<CommentManagementResource>()["Menu:CommentManagement"],
            icon: "fa fa-folder"
        );

        context.Menu.Items.AddIfNotContains(moduleMenu);
        return moduleMenu;
    }
    private static void AddMenuItemComments(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
    {
        parentMenu.AddItem(
            new ApplicationMenuItem(
                Menus.CommentManagementMenus.Comments,
                context.GetLocalizer<CommentManagementResource>()["Menu:Comments"],
                "/CommentManagement/Comments",
                icon: "fa fa-file-alt",
                requiredPermissionName: CommentManagementPermissions.Comments.Default
            )
        );
    }
}