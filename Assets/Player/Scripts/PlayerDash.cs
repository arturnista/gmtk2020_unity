using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    
    [SerializeField]
    private float _dashSpeed = 20f;
    [SerializeField]
    private float _cooldown = 1f;

    private PlayerItem _playerItem;
    private Movement _movement;

    private float _cooldownTime;

    void Awake()
    {
        _playerItem = GetComponent<PlayerItem>();
        _movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (_cooldownTime > 0)
        {
            _cooldownTime -= Time.deltaTime;
            return;
        }
        
        if (_playerItem.CurrentItem == null)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                _movement.ExtraVelocity += transform.right * _dashSpeed;
                _cooldownTime = _cooldown;
            }
        }
    }

}
