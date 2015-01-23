using System;
using System.Collections.Generic;
using System.Text;

using Windows.Storage;

namespace Moegirlpedia
{
    /// <summary>
    /// This class manages all settings of the App.
    /// You may store and retrieve settings.
    /// Currently versioning is not supported. We'll try hard to make backward compatibility.
    /// Versioning will be added when needed.
    /// </summary>
    class SettingManager
    {
        ApplicationDataContainer roamingSettings = null;
        ApplicationDataContainer localSettings = null;

        public SettingManager()
        {
            roamingSettings = ApplicationData.Current.RoamingSettings;
            localSettings = ApplicationData.Current.LocalSettings;
        }

        /// <summary>
        /// Set a setting. If the setting does not exsit, create a new setting.
        /// 
        /// Local and roaming setting key can be same. i.e. you may create a setting 
        /// called 'foo' in both local and roaming setting with different values.
        /// </summary>
        /// <param name="key">Key of the setting</param>
        /// <param name="value">Value of the setting</param>
        /// <param name="local">False if is local setting, or true if to be roamed</param>
        public void SetSetting(string key, Object value, bool local = false)
        {
            if (local)
                localSettings.Values[key] = value;
            else
                roamingSettings.Values[key] = value;
        }

        /// <summary>
        /// Get the setting with a key
        /// </summary>
        /// <param name="key">Key of the setting</param>
        /// <param name="local">False if is local setting, or true if to be roamed</param>
        /// <returns>Value of the setting</returns>
        public Object GetSetting(string key, bool local = false)
        {
            if (local)
                return localSettings.Values[key];
            else
                return roamingSettings.Values[key];
        }

        /// <summary>
        /// Delete the setting with specific key
        /// </summary>
        /// <param name="key">Key of the setting to be deleted</param>
        /// <param name="local">False if is local setting, or true if to be roamed</param>
        public void DelSetting(string key, bool local = false)
        {
            if (local)
                localSettings.Values.Remove(key);
            else
                roamingSettings.Values.Remove(key);
        }

        /// <summary>
        /// Delete all exsiting settings
        /// </summary>
        /// <param name="local">True if delete local settings, false to delete roaming settings</param>
        public void ClearSetting(bool local = false)
        {
            if (local)
                localSettings.Values.Clear();
            else
                roamingSettings.Values.Clear();
        }
    }
}
