using TMPro;
using UnityEngine.UI;
using UnityEngine;

public static class StringValidationExtention
{
    public static Validator Rules(this TMP_Text component) => new Validator(component, component.text);
}
