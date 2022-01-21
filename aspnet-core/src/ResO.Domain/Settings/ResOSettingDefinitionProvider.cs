using Volo.Abp.Settings;

namespace ResO.Settings;

public class ResOSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ResOSettings.MySetting1));
    }
}
