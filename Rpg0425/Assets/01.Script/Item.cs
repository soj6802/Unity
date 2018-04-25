using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    public enum eKind { SWORD = 0, HELMET, ARMOR, GLOVES, SHOES, HPPOTION, NECKLACE, RING };
    public string m_strName;
    public eKind m_eKind;
    public string m_strComent;
    public float m_nFuctionF;
    public float m_nFuctionS;
    public float m_nFuctionT;
    public int m_nGold;
    public Item() { }
    public Item(string name, eKind kind, string coment, float fucF, float fucS, float fucT, int gold)
    {
        m_strName = name;
        m_eKind = kind;
        m_strComent = coment;
        m_nFuctionF = fucF;
        m_nFuctionS = fucS;
        m_nFuctionT = fucT;
        m_nGold = gold;
    }

}