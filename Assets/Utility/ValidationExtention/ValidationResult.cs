using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationResult
{
    public readonly bool Success;
    public readonly string ErrorMessage;

    public ValidationResult(bool result, string errorMessage = "")
            => (Success, ErrorMessage) = (result, errorMessage);
}

