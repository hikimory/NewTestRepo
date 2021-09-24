using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public static class XRRayInteractorExtention
{
    public static bool TryGetComponentInParent<T>(this GameObject target, out T obj) where T : class
    {
        obj = null;
        var component = target.GetComponentInParent<T>();

        if (component == null) return false;
        
        obj = component;
        return true;
    }

    public static bool TryGetComponentInParent<T>(this Transform target, out T obj) where T : class
    {
        obj = null;
        var component = target.GetComponentInParent<T>();

        if (component == null) return false;
        
        obj = component;
        return true;
    }

    public static bool TryGetComponentInChildren<T>(this GameObject target, out T obj) where T : class
    {
        obj = null;
        var component = target.GetComponentInParent<T>();

        if (component == null) return false;
        
        obj = component;
        return true;
    }

    public static bool TryGetComponentInChildren<T>(this Transform target, out T obj) where T : class
    {
        obj = null;
        var component = target.GetComponentInParent<T>();

        if (component == null) return false;
        
        obj = component;
        return true;
    }
}
