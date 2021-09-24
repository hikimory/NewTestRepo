using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using VR.Toolkit;

public class JumpState : State
{
    private readonly Transform _transform = null;
    private readonly Renderer _renderer = null;
    private readonly float _power = 1f;
    private bool _inAir = false;
    public JumpState(Transform transform, Renderer renderer)
    {
        _transform = transform;
        _renderer = renderer;
        AddTransition(typeof(IdleState));
        AddTransition(typeof(MoveState));
    }
    public override bool CanTransact(IState state)
    {
        if (_inAir) return false;
        return base.CanTransact(state);
    }
    public override void Enter()
    {
        base.Enter();
        _renderer.material.color = Color.magenta;
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
        
        if (Input.GetKeyDown(KeyCode.Space) && _inAir == false)
        {
            Jump(_power);
        }
    }
    private async void Jump(float power)
    {
        _inAir = true;
        var delta = 0f;
        var defaultPosition = _transform.position;
        while (_transform.position.y < defaultPosition.y + power)
        {
            delta += 0.01f;
            _transform.position = new Vector3(_transform.position.x, defaultPosition.y + delta, _transform.position.z);
            await Task.Yield();
        }
        delta = 0f;
        while (_transform.position.y > defaultPosition.y)
        {
            delta += 0.01f;
            _transform.position = new Vector3(_transform.position.x, _transform.position.y - delta, _transform.position.z);
            await Task.Yield();
        }
        _inAir = false;
    }
}
