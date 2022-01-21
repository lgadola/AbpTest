using ResO.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ResO.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ResOEntityFrameworkCoreModule),
    typeof(ResOApplicationContractsModule)
    )]
public class ResODbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
