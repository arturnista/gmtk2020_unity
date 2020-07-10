using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private float speed = 10; 
    public float Speed { get { return speed; } }

    [SerializeField]
    private float acceleration = 100; 
    public float Acceleration { get { return acceleration; } }

    private Vector3 _targetVelocity;
    private Vector3 _moveVelocity;
    public Vector3 MoveDirection { get; set; }
    public Vector3 ExtraVelocity { get; set; }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnDisable()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    void Update() 
    {

        Vector3 moveDirection = MoveDirection.normalized;

        _targetVelocity = moveDirection * speed;

        _moveVelocity = Vector3.MoveTowards(_moveVelocity, _targetVelocity, acceleration * Time.deltaTime);
        
        _rigidbody.velocity = _moveVelocity + ExtraVelocity;

        ExtraVelocity = Vector3.MoveTowards(ExtraVelocity, Vector3.zero, 150f * Time.deltaTime);

    }

}
