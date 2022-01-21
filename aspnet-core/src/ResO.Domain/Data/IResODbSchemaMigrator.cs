using System.Threading.Tasks;

namespace ResO.Data;

public interface IResODbSchemaMigrator
{
    Task MigrateAsync();
}
