using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]

public class Inventory : ScriptableObject
{
    //我是背包，创建背包时用我这个类型
    public List<GoodsItem> GoodsItems = new List<GoodsItem>();
}
