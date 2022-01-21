using System;
using System.Collections.Generic;
using System.Text;
using ResO.Localization;
using Volo.Abp.Application.Services;

namespace ResO;

/* Inherit your application services from this class.
 */
public abstract class ResOAppService : ApplicationService
{
    protected ResOAppService()
    {
        LocalizationResource = typeof(ResOResource);
    }
}
