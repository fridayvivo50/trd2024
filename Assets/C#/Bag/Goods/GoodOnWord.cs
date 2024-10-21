using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodOnWord : MonoBehaviour
{
    //世界上面的道具
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public GoodsItem thisItem;
    public Inventory thisInventory;
    public void AddNewItem()
    {
        if (!thisInventory.GoodsItems.Contains(thisItem))
        {
            InventoryManager.RefreshItem();
            thisInventory.GoodsItems.Add(thisItem);
            thisItem.itemHeld++;
        }
        else
        {
            thisItem.itemHeld++;
        }
    }
}
