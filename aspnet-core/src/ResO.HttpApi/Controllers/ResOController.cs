using ResO.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ResO.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ResOController : AbpControllerBase
{
    protected ResOController()
    {
        LocalizationResource = typeof(ResOResource);
    }
}
