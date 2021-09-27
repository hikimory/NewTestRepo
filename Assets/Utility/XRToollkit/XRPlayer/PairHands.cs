using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PairHands
{
    [SerializeField] private Hand m_leftHand = null;
    [SerializeField] private Hand m_rightHand = null;

    public Hand LeftHand => m_leftHand;
    public Hand RightHand => m_rightHand;

    public void Show()
    {
        m_leftHand.Show();
        m_rightHand.Show();
    }

    public void Hide()
    {
        m_leftHand.Show();
        m_rightHand.Show();
    }
}
