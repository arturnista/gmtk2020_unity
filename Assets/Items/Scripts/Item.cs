using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField]
    private ItemData m_Data = default;
    public ItemData Data { get => m_Data; }
    
    private SpriteRenderer _spriteRenderer;

    public void Construct(ItemData data)
    {
        m_Data = data;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _spriteRenderer.sprite = m_Data.Sprite;
        name = m_Data.Name;
    }

    void Awake()
    {
        if (m_Data != null)
        {
            Construct(m_Data);
        }
    }

    void OnDrawGizmos()
    {
        if (m_Data != null)
        {
            Construct(m_Data);
        }
    }
    
}
