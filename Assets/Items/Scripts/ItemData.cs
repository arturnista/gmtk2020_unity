using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    
    public string Name;
    public Sprite Sprite;
    [Space]
    public GameObject Prefab;

    public void Create(Vector3 position)
    {
        Create(position, Vector3.zero);
    }

    public void Create(Vector3 position, Vector3 throwDirection)
    {
        GameObject itemCreated = Instantiate(Prefab, position, Quaternion.identity);
        itemCreated.GetComponent<Item>().Construct(this);
        if (throwDirection != Vector3.zero)
        {
            itemCreated.GetComponent<Rigidbody2D>().AddForce(throwDirection * 100f, ForceMode2D.Impulse);
        }
    }

}
