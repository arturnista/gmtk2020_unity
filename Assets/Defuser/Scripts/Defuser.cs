using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Defuser : MonoBehaviour
{
    [SerializeField]
    private float _defuseRequired = 100f;
    [SerializeField]
    private CircleCollider2D _triggerCollider = default;
    [Space]
    [SerializeField]
    private Image _wantedItemImage;
    [SerializeField]
    private Image _nextItemImage;
    private Image _defuseAmountImage;

    private Queue<ItemData> _itemList;

    private float _defuseAmount;

    private ItemData _wantedItem;
    private bool _isWaitingForItem;

    void Awake()
    {
        _isWaitingForItem = true;
        _defuseAmountImage = GameObject.Find("DefuseCanvas/Value").GetComponent<Image>();
        _defuseAmountImage.fillAmount = 0f;
        
        _itemList = new Queue<ItemData>();
        List<Item> items = GameObject.FindObjectsOfType<Item>().ToList();
        for (int i = 0; i < 10; i++)
        {
            Item item = items[Random.Range(0, items.Count)];
            _itemList.Enqueue(item.Data);
            items.Remove(item);
        }

        GetNewItem();
    }

    void GetNewItem()
    {
        if (_itemList.Count == 0) return;

        _wantedItem = _itemList.Dequeue();
        _wantedItemImage.gameObject.SetActive(true);
        _wantedItemImage.sprite = _wantedItem.Sprite;

        if (_itemList.Count > 0)
        {
            _nextItemImage.gameObject.SetActive(true);
            _nextItemImage.sprite = _itemList.Peek().Sprite;
        }
        else
        {
            _nextItemImage.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (_isWaitingForItem)
        {
            Item item = collider.GetComponent<Item>();
            if (item)
            {
                ConsumeItem(item);
            }
        }
    }

    void ConsumeItem(Item item)
    {
        StartCoroutine(ConsumeCoroutine(item));
    }

    IEnumerator ConsumeCoroutine(Item item)
    {
        
        ItemData itemData = item.Data;
        _isWaitingForItem = false;

        yield return new WaitForEndOfFrame();
        
        _nextItemImage.gameObject.SetActive(false);
        _wantedItemImage.gameObject.SetActive(false);
        Destroy(item.gameObject);

        yield return new WaitForSeconds(3f);

        if (itemData == _wantedItem)
        {

            _defuseAmount += 10f;
            _defuseAmountImage.fillAmount = Mathf.Clamp01(_defuseAmount / _defuseRequired);
            UIFlashDisplay.Instance.Flash(new Color(.3f, 1f, .3f, .3f));
            GetNewItem();

        }
        else
        {

            Vector3 direction = Random.insideUnitCircle.normalized;
            itemData.Create(transform.position + direction * 1.5f, direction);

            UIFlashDisplay.Instance.Flash(new Color(1f, .3f, .3f, .7f));
            CountdownController.Instance.WrongTool();

            yield return new WaitForSeconds(.5f);
            _wantedItemImage.gameObject.SetActive(true);
            if (_itemList.Count > 0) _nextItemImage.gameObject.SetActive(true);            

        }
        
        if (_defuseAmount >= _defuseRequired || _wantedItem == null)
        {    
            UIFinalMenu.WON_GAME = true;
            SceneManager.LoadScene("FinalMenu");
        }
        else
        {
            _isWaitingForItem = true;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _triggerCollider.radius, 1 << LayerMask.NameToLayer("Item"));
            foreach (var collider in colliders)
            {
                Item castItem = collider.GetComponent<Item>();
                if (castItem)
                {
                    ConsumeItem(castItem);
                    break;
                }
            }
        }


    }

}
