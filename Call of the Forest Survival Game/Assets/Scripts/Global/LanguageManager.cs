using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
public enum Languages { English, Russian, Ukrainian, Czech};
public static class LanguageManager
{
    public static Languages GameLanguage;
    const string PathToJSON = "Languages.json";
    const string PathToJSONdebug = "Other/Languages.json";
    static dynamic SerializedLanguages;
    public static void Init()
    {
        if (Application.isEditor)
        {
            using (StreamReader stream = new StreamReader(PathToJSONdebug))
            {
                var text = stream.ReadToEndAsync().Result;
                SerializedLanguages = JsonConvert.DeserializeObject(text);
            }
        }
    }
}
