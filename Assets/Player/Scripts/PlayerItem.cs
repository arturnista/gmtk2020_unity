using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _itemHolderSprite;

    private ItemData m_CurrentItem;
    public ItemData CurrentItem { get => m_CurrentItem; }

    void Awake()
    {
        _itemHolderSprite.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_CurrentItem == null)
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
                m_CurrentItem = item.Data;   
                _itemHolderSprite.gameObject.SetActive(true);
                _itemHolderSprite.sprite = m_CurrentItem.Sprite;
                Destroy(collider.gameObject);
                break;
            }
        }
    }

    void ThrowItem()
    {
        _itemHolderSprite.gameObject.SetActive(false);
        m_CurrentItem.Create(transform.position, transform.right);
        m_CurrentItem = null;
    }

}
