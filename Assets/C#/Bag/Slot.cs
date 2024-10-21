using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //���Ǳ�������ĵ��߸���
    [SerializeField] private Text Num;
    public GoodsItem slotItem;
    public Image slotImage;

    public void ShowNum()//��ʾ����ӵ������
    {
        Num.text = slotItem.itemHeld.ToString();
    }

    public void ItemOnClick()//���ص���ť��
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo, slotItem.itemHeld);

    }
}
