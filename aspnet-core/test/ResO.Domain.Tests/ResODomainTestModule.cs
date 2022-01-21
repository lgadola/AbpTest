using ResO.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ResO;

[DependsOn(
    typeof(ResOEntityFrameworkCoreTestModule)
    )]
public class ResODomainTestModule : AbpModule
{

}
