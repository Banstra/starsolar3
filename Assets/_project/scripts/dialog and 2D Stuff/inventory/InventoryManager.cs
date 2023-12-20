using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new();
    public Transform ItemContent;
    public GameObject InventoryItem;
    private void Awake()
    {
        Instance = this;

    }

    public void Add(Item Item)
    {
        Items.Add(Item);
    }
    public void Remove(Item Item)
    {
        Items.Remove(Item);
    }
    public void ListItems()
    {
        foreach (Transform Item in ItemContent)
        {
            Destroy(Item.gameObject);
        }

        foreach (var Item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("itemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("icon").GetComponent<Image>();
            itemName.text = Item.itemName;
            itemIcon.sprite = Item.icon;

        }
    }
}
