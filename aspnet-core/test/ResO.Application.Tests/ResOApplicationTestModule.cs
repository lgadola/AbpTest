using Volo.Abp.Modularity;

namespace ResO;

[DependsOn(
    typeof(ResOApplicationModule),
    typeof(ResODomainTestModule)
    )]
public class ResOApplicationTestModule : AbpModule
{

}
