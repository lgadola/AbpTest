using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ResO;

[Dependency(ReplaceServices = true)]
public class ResOBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ResO";
}
