using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionLayerExample : MonoBehaviour
{
    public LayerMask interactorMask = ~0;
    public LayerMask interactableMask = ~0;

    // Update is called once per frame
    void Update()
    {
        print(interactorMask.value);
        print(interactableMask.value);

        print(interactorMask & interactableMask);
        Debug.Log(Application.dataPath);
    }
}
