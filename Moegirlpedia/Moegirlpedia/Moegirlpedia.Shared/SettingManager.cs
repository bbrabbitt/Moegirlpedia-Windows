using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// <summary>
        /// Set a setting. If the setting does not exsit, create a new setting.
        /// 
        /// Local and roaming setting key can be same. i.e. you may create a setting 
        /// called 'foo' in both local and roaming setting with different values.
        /// </summary>
        /// <param name="key">Key of the setting</param>
        /// <param name="value">Value of the setting</param>
        /// <param name="local">False if is local setting, or true if to be roamed</param>
        static public void SetSetting(string key, Object value, bool local = false)
        {
            Debug.WriteLine(String.Format("Setting: Set {0} as {1}, {2}", key, value, local ? "local storage" : "roaming"));
            if (local)
                ApplicationData.Current.LocalSettings.Values[key] = value;
            else
                ApplicationData.Current.RoamingSettings.Values[key] = value;
        }

        /// <summary>
        /// Get the setting with a key
        /// </summary>
        /// <param name="key">Key of the setting</param>
        /// <param name="local">False if is local setting, or true if to be roamed</param>
        /// <returns>Value of the setting</returns>
        static public Object GetSetting(string key, bool local = false)
        {
            Object value = null;
            if (local)
                value = ApplicationData.Current.LocalSettings.Values[key];
            else
                value = ApplicationData.Current.RoamingSettings.Values[key];
            Debug.WriteLine(String.Format("Setting: Get {0}, value is {1}, {2}", key, value, local ? "local storage" : "roaming"));
            return value;
        }

        /// <summary>
        /// Delete the setting with specific key
        /// </summary>
        /// <param name="key">Key of the setting to be deleted</param>
        /// <param name="local">False if is local setting, or true if to be roamed</param>
        static public void DelSetting(string key, bool local = false)
        {
            Debug.WriteLine(String.Format("Setting: Delete {0} setting, {2}", key, local ? "local storage" : "roaming"));
            if (local)
                ApplicationData.Current.LocalSettings.Values.Remove(key);
            else
                ApplicationData.Current.RoamingSettings.Values.Remove(key);
        }

        /// <summary>
        /// Delete all exsiting settings
        /// </summary>
        /// <param name="local">True if delete local settings, false to delete roaming settings</param>
        static public void ClearSetting(bool local = false)
        {
            Debug.WriteLine("Setting: Delete all " + (local ? "local" : "roaming") + " settings");
            if (local)
                ApplicationData.Current.LocalSettings.Values.Clear();
            else
                ApplicationData.Current.RoamingSettings.Values.Clear();
        }
    }
}
