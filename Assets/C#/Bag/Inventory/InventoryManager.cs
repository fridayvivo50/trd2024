using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //管理背包用我，挂载到相应对象上
    static InventoryManager instance;
    public Inventory GoodsBag;
    public GameObject slotGrids;
    public Slot slotPrefab;

    public Text itemInformation;
    public Text slotNum;

    private void OnEnable()
    {
        instance.itemInformation.text = "ovo";
        RefreshItem();
    }

    public static void UpdateItemInfo(string ItemDescription, int slotNum)//介绍，数量
    {
        instance.itemInformation.text = ItemDescription;
        instance.slotNum.text = "Have: " + slotNum.ToString();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            instance = this;
        }
        else
        {
            instance = this;
        }
    }

    public static void CreatNewItem(GoodsItem goodsitem)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotPrefab.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrids.transform);
        newItem.slotImage.sprite = goodsitem.itemSprite;
        newItem.slotItem = goodsitem;
        newItem.ShowNum();
    }
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrids.transform.childCount; i++)
        {
            if (instance.slotGrids.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGrids.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.GoodsBag.GoodsItems.Count; i++)
        {
            CreatNewItem(instance.GoodsBag.GoodsItems[i]);
        }
    }
}
