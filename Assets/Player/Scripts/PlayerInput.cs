using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private Movement _movement;
    private Look _look;
    private Camera _camera;

    void Awake()
    {
        _camera = Camera.main;
        _movement = GetComponent<Movement>();
        _look = GetComponent<Look>();
    }

    void Update()
    {
        Vector3 inputDirection = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
        
        if (inputDirection.sqrMagnitude != 0)
        {
            _look.LookDirection = inputDirection;
        }
        _movement.MoveDirection = inputDirection;
    }
    
}
