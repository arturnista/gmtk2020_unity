using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{

    private ItemData _holdingItem;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_holdingItem == null)
            {
                PickupItem();
            }
            else
            {
                
            }
        }
    }

    void PickupItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f, 1 << LayerMask.NameToLayer("Item"));
        foreach (var item in colliders)
        {
            
        }
    }

}
