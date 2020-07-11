using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxOpener : MonoBehaviour
{
    [SerializeField]
    private List <ItemData> toolsPrefabs;
    private Collider2D savedCollider;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && savedCollider != null)
        {
            Debug.Log("aperto");
            toolsPrefabs[Random.Range(0, toolsPrefabs.Count)].Create(transform.position);
            Destroy(savedCollider.gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "ItemBox")
        {
            savedCollider = collider2D;
            Debug.Log("colidiu");
        }
    }
}
