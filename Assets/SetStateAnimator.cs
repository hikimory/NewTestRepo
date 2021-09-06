using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStateAnimator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("HandController"))
        {
            HandDirectInteractor _interactor = other.GetComponent<HandDirectInteractor>();
            _interactor?.SetStateAnimator(AnimatorState.Enter);
            Debug.Log("OnTriggerEnter " + other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag.Equals("HandController"))
        {
            HandDirectInteractor _interactor = other.GetComponent<HandDirectInteractor>();
            _interactor?.SetStateAnimator(AnimatorState.Exit);
            Debug.Log("OnTriggerExit " + other.gameObject.name);
        }
    }
}
