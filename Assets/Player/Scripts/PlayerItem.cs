using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _itemHolderSprite;

    private ItemData _currentItem;

    void Awake()
    {
        _itemHolderSprite.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentItem == null)
            {
                PickupItem();
            }
            else
            {
                ThrowItem();
            }
        }
    }

    void PickupItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f, 1 << LayerMask.NameToLayer("Item"));
        foreach (var collider in colliders)
        {
            Item item = collider.GetComponent<Item>();
            if (item)
            {
                _currentItem = item.Data;   
                _itemHolderSprite.gameObject.SetActive(true);
                _itemHolderSprite.sprite = _currentItem.Sprite;
                Destroy(collider.gameObject);
                break;
            }
        }
    }

    void ThrowItem()
    {
        _itemHolderSprite.gameObject.SetActive(false);
        _currentItem.Create(transform.position, transform.right);
        _currentItem = null;
    }

}
