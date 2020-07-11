using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField]
    private ItemData _data = default;
    
    private SpriteRenderer _spriteRenderer;

    public void Construct(ItemData data)
    {
        _data = data;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _spriteRenderer.sprite = _data.Sprite;
        name = _data.Name;
    }

    void Awake()
    {
        if (_data != null)
        {
            Construct(_data);
        }
    }
    
}
