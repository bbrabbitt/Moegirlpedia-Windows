using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Windows.UI.Xaml.Data;


namespace Moegirlpedia
{
    class Preferences
    {
        // 'Cuz that annoying converter returns an object, we have to make an ``object collection'' here
        ObservableCollection<object> _wikiLanguageList = new ObservableCollection<object>()
        {
            "English",
            "中文",
            "日本語"
        };

        public ObservableCollection<object> WikiLanguageList
        {
            get
            {
                return _wikiLanguageList;
            }
        }

        public string WikiLanguage
        {
            get
            {
                Object lang = SettingManager.GetSetting("WikiLanguage");
                if (lang == null || !(lang is string))
                    lang = "en";
                
                return lang as string;                
            }
            set
            {
                SettingManager.SetSetting("WikiLanguage", value as string);
            }
        }
    }

    /// <summary>
    /// Value converter to convert between "English" and "en", etc.
    /// </summary>
    class ISO639ToCommonLangNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value as string)
            {
                case "en":
                    return "English";
                case "ja":
                    return "日本語";
                case "zh":
                    return "中文";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // What a nice syntax sugar!
            switch (value as string)
            {
                case "English":
                    return "en";
                case "日本語":
                    return "ja";
                case "中文":
                    return "zh";
                default:
                    return null;    // Unrecognizable language. This should not happen.
            }
        }
    }
}
