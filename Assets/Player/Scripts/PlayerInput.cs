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
        Vector3 lookDirection = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        _movement.MoveDirection = inputDirection;
        _look.LookDirection = lookDirection;
    }
    
}
