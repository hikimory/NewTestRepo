using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private readonly Transform _transform = null;
    private readonly Renderer _renderer = null;
    public MoveState(Transform transform, Renderer renderer)
    {
        _transform = transform;
        _renderer = renderer;
        AddTransition(typeof(IdleState));
        AddTransition(typeof(JumpState));
    }
    public override void Enter()
    {
        base.Enter();
        _renderer.material.color = Color.blue;
    }
    public override void Exit()
    {
        base.Exit();
        _renderer.material.color = Color.red;
    }
    public override void Update()
    {
        base.Update();
        
        var newPosition = _transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition.z += 0.05f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition.z -= 0.05f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= 0.05f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += 0.05f;
        }
        _transform.position = newPosition;
    }
}
