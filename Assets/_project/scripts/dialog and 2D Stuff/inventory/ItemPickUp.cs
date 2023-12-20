using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private Item _item;

    public void Pickup()
    {
        InventoryManager.Instance.Add(_item);
        gameObject.SetActive(false);
    }
}
