using JS.Abp.CommentManagement.Permissions;
using JS.Abp.CommentManagement.Localization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Volo.Abp.Authorization.Permissions;

namespace JS.Abp.CommentManagement.Web.Menus;

public class CommentManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name != StandardMenus.Main)
        {
            return;
        }

        var moduleMenu = AddModuleMenuItem(context); //Do not delete `moduleMenu` variable as it will be used by ABP Suite!

        AddMenuItemComments(context, moduleMenu);
    }

    private static ApplicationMenuItem AddModuleMenuItem(MenuConfigurationContext context)
    {
        var moduleMenu = new ApplicationMenuItem(
            CommentManagementMenus.Prefix,
            displayName: "CommentManagement",
            "~/CommentManagement",
            icon: "fa fa-globe");

        //Add main menu items.
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