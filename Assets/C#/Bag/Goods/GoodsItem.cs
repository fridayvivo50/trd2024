using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GoodsItem", menuName = "Inventory/New GooldItem")]
public class GoodsItem : ScriptableObject
{
    //我是道具，创建道具时创建我这个类型
    public string itemName;
    public Sprite itemSprite;
    public int itemHeld;
    [TextArea]
    public string itemInfo;
}
