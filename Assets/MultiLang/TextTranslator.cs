using TMPro;
using UnityEngine;

public class TextTranslator : MonoBehaviour
{
    [SerializeField] 
	string key;

	void Start ()
	{
		GetComponent <TMP_Text> ().text = GameMultiLang.GetTraduction (key);
	}
}

