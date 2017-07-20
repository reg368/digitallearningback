using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digitallearningback.Util
{
    public class AppSettingHelper
    {
        public static String GetValueByKey(String key) {
            String value = null;

            System.Configuration.Configuration rootWebConfig1 =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);

            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement customSetting =
                    rootWebConfig1.AppSettings.Settings[key];
                if (null != customSetting)
                     return customSetting.Value;
            }

            return value;
        }
    }
}