using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxOpener : MonoBehaviour
{
    private bool canOpen;
    [SerializeField]
    private List <ItemData> toolsPrefabs;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canOpen)
        {
            Debug.Log("aperto");
            toolsPrefabs[Random.Range(0, toolsPrefabs.Count)].Create(transform.position);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.tag == "ItemBox")
        {
            Debug.Log("colidiu");
            canOpen = true;
        }
    }
}
