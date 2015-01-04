using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;

namespace Lion.Core
{
    public class CommonUtility
    {
        public T LoadSetting<T>(string settingKey)
        {
            string settingValue = ConfigurationManager.AppSettings[settingKey];

            return TryParse<T>(settingValue);
        }

        public T TryParse<T>(object value)
        {
            if(value != null)
            {
                return (T)( TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value)) ;
            }
            else
            {
                throw (new Exception("Unable to convert setting value"));
            }
           
        }
    }
}
