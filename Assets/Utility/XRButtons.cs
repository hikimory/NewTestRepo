using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class XRButtons : MonoBehaviour
{
    [SerializeField] private List<XRButton> _leftButtons = null;
    [SerializeField] private List<XRButton> _rightButtons = null;

    private static XRButtons _instance;
    
    public static XRButtons Instance => _instance;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        } else {
            _instance = this;
        }
    }

    public XRButton GetButtonByKey(ControllerType controllerType, ButtonType buttonType)
    {
        if(controllerType == ControllerType.Left)
        {
            return _leftButtons.Where(x => x.TypeButton == buttonType).First();
        }
        else
        {
            return _rightButtons.Where(x => x.TypeButton == buttonType).First();
        }
    }
}
