using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableScriptMono : MonoBehaviour
{
    private AsyncOperationHandle  _addressableLoadHandle;
    private Dictionary<AssetReference, object> _resourceDictionary = new Dictionary<AssetReference, object>();
    
    protected void LoadReource<T>(AssetReference reference, Action<T> callback)
    {
        if(_addressableLoadHandle.IsDone)
            StartCoroutine(LoadReourceCoroutine<T>(reference, callback));
    }

    private IEnumerator LoadReourceCoroutine<T>(AssetReference reference, Action<T> callback)
    {
        if(_resourceDictionary.ContainsKey(reference))
            callback.Invoke((T)_resourceDictionary[reference]);

        ClearAddressableHadler();
        
        _addressableLoadHandle = reference.LoadAssetAsync<T>();
        
        yield return _addressableLoadHandle;

        if (_addressableLoadHandle.Status == AsyncOperationStatus.Succeeded) {
            callback.Invoke((T)_addressableLoadHandle.Result);
            _resourceDictionary.Add(reference, _addressableLoadHandle.Result);
        }
    }


    protected void ReleaseResources()
    {
        if(_resourceDictionary.Count == 0)
            return;
        
        _resourceDictionary.Clear();

        ClearAddressableHadler();
    }

    protected void ReleaseResource(AssetReference reference)
    {
        if(!_resourceDictionary.ContainsKey(reference))
            return;
        
        _resourceDictionary.Remove(reference);

        ClearAddressableHadler();
    }

    private void ClearAddressableHadler()
    {
        if (_addressableLoadHandle.IsValid())
        {
            Addressables.Release(_addressableLoadHandle);
        }
    }
}
