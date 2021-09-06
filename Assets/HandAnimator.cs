using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimatorState : uint
{
    Undefined = 0,
    Enter = 1,
    Exit = 2
}



public class HandAnimator : MonoBehaviour
{

    [SerializeField] private string m_startState;
    [SerializeField] private string m_endState;

    [SerializeField] private Animator m_animator;
    private AnimatorState _currentState = AnimatorState.Undefined;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(AnimatorState state)
    {
        _currentState = state;
        PlayAnimation();
    }
    
    private void PlayAnimation()
    {
        if(m_animator == null)
            return;
        
        switch (_currentState)
        {
            case AnimatorState.Enter:
                m_animator.Play(m_startState, -1);
                m_animator.SetTrigger("EnterZone");
                m_animator.ResetTrigger("ExitZone");
                break;
            case AnimatorState.Exit:
                m_animator.SetTrigger("ExitZone");
                m_animator.ResetTrigger("EnterZone");
                //m_animator.Play(m_endState, -1);
                break;    
            default:
            break;
        }
    }
}
