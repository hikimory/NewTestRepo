using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableTestScript : AddressableScriptMono
{
    [SerializeField] private AssetReference _reference = null;
    [SerializeField] private MeshRenderer _renderer = null;
    
    
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        ChangeMaterial();
    }

    private void ChangeMaterial()
    {
        LoadReource<Material>(_reference, SetMaterial);
    }

    private void SetMaterial(Material material)
    {
        _renderer.material = material;
    }
}
