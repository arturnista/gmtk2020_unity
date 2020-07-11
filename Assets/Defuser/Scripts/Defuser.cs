using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defuser : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> _allItems = default;
    [SerializeField]
    private float _defuseRequired = 100f;
    [SerializeField]
    private CircleCollider2D _triggerCollider = default;
    [Space]
    [SerializeField]
    private Image _wantedItemImage;
    private Image _defuseAmountImage;

    private float _defuseAmount;

    private ItemData _wantedItem;
    private bool _isWaitingForItem;

    void Awake()
    {
        _isWaitingForItem = true;
        _defuseAmountImage = GameObject.Find("DefuseCanvas/Value").GetComponent<Image>();
        _defuseAmountImage.fillAmount = 0f;
        GetNewItem();
    }

    void GetNewItem()
    {
        _wantedItem = _allItems[Random.Range(0, _allItems.Count)];
        _wantedItemImage.sprite = _wantedItem.Sprite;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (_isWaitingForItem)
        {
            Item item = collider.GetComponent<Item>();
            if (item)
            {
                if (item.Data == _wantedItem)
                {
                    ConsumeItem(item);
                }
            }
        }
    }

    void ConsumeItem(Item item)
    {
        StartCoroutine(ConsumeCoroutine(item));
    }

    IEnumerator ConsumeCoroutine(Item item)
    {
        _wantedItemImage.gameObject.SetActive(false);
        Destroy(item.gameObject);

        yield return new WaitForSeconds(3f);

        GetNewItem();
        _defuseAmount += 10f;
        _defuseAmountImage.fillAmount = Mathf.Clamp01(_defuseAmount / _defuseRequired);

        if (_defuseAmount >= _defuseRequired)
        {
            Debug.Log("GANHOU!");
        }


        _isWaitingForItem = true;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _triggerCollider.radius, 1 << LayerMask.NameToLayer("Item"));
        foreach (var collider in colliders)
        {
            Item castItem = collider.GetComponent<Item>();
            if (castItem)
            {
                if (castItem.Data == _wantedItem)
                {
                    ConsumeItem(castItem);
                    _isWaitingForItem = false;
                    break;
                }
            }
        }

        if (_isWaitingForItem)
        {
            _wantedItemImage.gameObject.SetActive(true);
        }
    }

}
