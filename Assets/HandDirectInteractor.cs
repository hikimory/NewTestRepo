using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandDirectInteractor : XRDirectInteractor
{
    private HandAnimator _animator;

    private void Start() {
        _animator = GetComponent<HandAnimator>();
    }

    public void SetStateAnimator(AnimatorState state)
    {
        _animator.SetState(state);
    }
}

