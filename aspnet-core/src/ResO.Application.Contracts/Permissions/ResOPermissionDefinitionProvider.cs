using ResO.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ResO.Permissions;

public class ResOPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ResOPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ResOPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ResOResource>(name);
    }
}
