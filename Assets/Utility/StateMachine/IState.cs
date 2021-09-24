using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR.Toolkit
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
        bool CanTransact(IState state);
    }
}