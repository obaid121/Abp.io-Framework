using BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace BookStore.Permissions
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BookStorePermissions.GroupName);

            myGroup.AddPermission(BookStorePermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(BookStorePermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));

            var bookPermission = myGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Books"));
            bookPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Create"));
            bookPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Edit"));
            bookPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Delete"));

            var authorPermission = myGroup.AddPermission(BookStorePermissions.Authors.Default, L("Permission:Authors"));
            authorPermission.AddChild(BookStorePermissions.Authors.Create, L("Permission:Create"));
            authorPermission.AddChild(BookStorePermissions.Authors.Edit, L("Permission:Edit"));
            authorPermission.AddChild(BookStorePermissions.Authors.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}