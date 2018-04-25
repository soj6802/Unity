using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Item
{
 
    public List<Item> m_ItemList = new List<Item>();

    public void Init()
    {
        m_ItemList.Add(new Item("칼날", Item.eKind.SWORD, "공격력: 10396, 치명타 확률 12.5%, 초당 공격횟수 1.75", 10396, 0.125f,1.75f,100));
        m_ItemList.Add(new Item("투구", Item.eKind.HELMET, "방어력 : 9336, 체력 5000, 치명타 피해량 : 50%", 9336, 5000,0.5f, 100));
        m_ItemList.Add(new Item("갑옷", Item.eKind.ARMOR, "방어력 : 10371, 체력 5000, 치명타 피해량 : 56%", 10371, 5000,0.56f, 100));
        m_ItemList.Add(new Item("장갑", Item.eKind.GLOVES, "방어력 : 14928, 체력 5000, 치명타 피해량 : 10%", 14928, 5000,0.1f, 100));
        m_ItemList.Add(new Item("신발", Item.eKind.SHOES, "방어력 : 14089, 체력 5000, 치명타 피해량 : 5%", 14089, 5000,0.5f, 100));
        m_ItemList.Add(new Item("HP포션", Item.eKind.HPPOTION, "체력 30%회복", 100, 0, 0, 100));
        m_ItemList.Add(new Item("목걸이", Item.eKind.NECKLACE, "치명타 확률 5%, 회피확률 10%", 0.5f, 0.1f, 0, 100));
        m_ItemList.Add(new Item("반지", Item.eKind.RING, "치명타 확률 5%, 회피확률 5%", 0.5f, 0.5f, 0, 100));

    }

    public Item GetItem(int idx)
    {
        return m_ItemList[idx];
    }

    void Start()
    {
        Init();
    }
}
