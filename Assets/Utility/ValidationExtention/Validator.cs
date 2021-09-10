using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class Validator
{
    private readonly TMP_Text _component;
    private readonly string _content;
    private bool _success = true;
    public string ErrorMessage {get; private set;}
    
    public Validator(TMP_Text component, string content)
            => (_component, _content) = (component, content);
    
    public Validator MinCharacter(int count)
    {
        if(_success == false)
            return this;

        if(_content.Length < count)
        {
            _success = false;
            ErrorMessage = $"Minimum number of characters {count}";
        }
        
        return this;
    }

    public Validator IsNotNullOrEmpty()
    {
        if(_success == false)
            return this;

        if(string.IsNullOrEmpty(_content) || _content.Trim().Length == 0)
            _success = false;
        
        return this;
    }

    public Validator IsEmail()
    {
        if(_success == false)
            return this;

        string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
        
        if(Regex.IsMatch(_content, pattern) == false)
        {
            _success = false;
            ErrorMessage = "Invalid email";
        }
        
        return this;
    }

    public Validator EqualTo(TMP_Text field)
    {
        if(_success == false)
            return this;

        if(_content.Equals(field.text))
        {
            _success = false;
            ErrorMessage = $"Not Equal {field.gameObject.name}";
        }
        return this;
    }

    public ValidationResult Validate() 
    {
        if(_success)
        {
            return new ValidationResult(_success);
        }
        return new ValidationResult(_success, ErrorMessage);
    }

}
