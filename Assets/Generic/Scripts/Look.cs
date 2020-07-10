using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{

    public Vector3 LookDirection { get; set; }
    
    void Awake()
    {
    }

    void Update()
    {
        LookDirection.Normalize();
        float angle = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    
}
