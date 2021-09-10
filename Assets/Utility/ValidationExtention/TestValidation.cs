using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TestValidation : MonoBehaviour
{

    public TMP_Text field;

    // Start is called before the first frame update
    void Start()
    {
        ValidationResult result = field.Rules().IsNotNullOrEmpty().IsEmail().Validate();
        Debug.Log(result.Success);
        Debug.Log(result.ErrorMessage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
