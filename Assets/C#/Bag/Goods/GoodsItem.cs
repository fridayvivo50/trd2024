using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GoodsItem", menuName = "Inventory/New GooldItem")]
public class GoodsItem : ScriptableObject
{
    //���ǵ��ߣ���������ʱ�������������
    public string itemName;
    public Sprite itemSprite;
    public int itemHeld;
    [TextArea]
    public string itemInfo;
}
