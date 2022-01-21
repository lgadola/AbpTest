using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ResO.Data;

/* This is used if database provider does't define
 * IResODbSchemaMigrator implementation.
 */
public class NullResODbSchemaMigrator : IResODbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
