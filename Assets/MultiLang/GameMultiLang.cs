using System;
using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public class GameMultiLang : MonoBehaviour
{
	public static GameMultiLang Instance;

	public static Dictionary<string, string> Fields;

	[SerializeField] string defaultLang = "English";

	public string DefaultLang
	{
        get
        {
            return defaultLang;
        }
        set
        {
            defaultLang = value;
        }
	}

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}

		LoadLanguage ();
	}

    private void LoadLanguage ()
    {
        if (Fields == null)
			Fields = new Dictionary<string, string> ();
		
		Fields.Clear ();

        string language = PlayerPrefs.GetString ("_language", defaultLang);
        string path = Application.dataPath + "/Localization/Lang.xml";

        var xml = new XmlDocument();
        xml.Load(path);

        var element = xml.DocumentElement[language];
        if (element != null)
        {
            var elemEnum = element.GetEnumerator();
            while (elemEnum.MoveNext())
            {
                var xmlItem = (XmlElement)elemEnum.Current;
                Fields.Add (xmlItem.GetAttribute("name"), xmlItem.InnerText);
            }
        }
        else
        {
            Debug.LogError("The specified language does not exist: " + language);
        }
    }

	public static string GetTraduction (string key)
	{
		if (!Fields.ContainsKey (key)) {
			Debug.LogError ("There is no key with name: [" + key + "] in your text files");
			return null;
		}

		return Fields [key];
	}
}
