using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hand
{
    #region Inspector
    [SerializeField] private GameObject m_prefab;
    [SerializeField] private Renderer m_render;
    [SerializeField] private Transform m_attach;
    [SerializeField] private Animator m_animator;
    #endregion

    public Transform Attach => m_attach;
    public Animator Animator => m_animator;

    public void Show()
    {
        SetStatus(true);
    }

    public void Hide()
    {
        SetStatus(false);
    }

    private void SetStatus(bool status)
    {
        m_render.enabled = status;
        m_animator.enabled = status;
    }
}
