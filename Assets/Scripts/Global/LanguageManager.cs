using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
public enum Languages { English, Russian, Ukrainian, Czech};
public static class LanguageManager
{
    public static Languages GameLanguage;
    static string PathToJSON = Application.dataPath + @"\Languages.json";
    static string PathToJSONdebug = Application.dataPath + @"\Other\Languages.json";
    static dynamic SerializedLanguages;
    public static void Init()
    {
        if (Application.isEditor && File.Exists(PathToJSONdebug))
        {
            using (StreamReader stream = new StreamReader(PathToJSONdebug))
            {
                var text = stream.ReadToEndAsync().Result;
                SerializedLanguages = JsonConvert.DeserializeObject(text);
            }
        }
    }
}
