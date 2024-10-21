using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //我是背包里面的道具格子
    [SerializeField] private Text Num;
    public GoodsItem slotItem;
    public Image slotImage;

    public void ShowNum()//显示道具拥有数量
    {
        Num.text = slotItem.itemHeld.ToString();
    }

    public void ItemOnClick()//挂载到按钮上
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo, slotItem.itemHeld);

    }
}
