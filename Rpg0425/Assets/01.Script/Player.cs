using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_fHp;
    public float m_fMaxHP;
    public float m_fStr;
    public float m_fMaxStr;
    public float m_fDef;
    public float m_fMaxHp;
    public int m_nLevel;
    public float m_fExp;
    public float m_fCriticalPower;
    public float m_fCriticalChance;
    public float m_fMaxCriticalPower;
    public float m_fMaxCriticalChance;
    public float m_fAvoid;
    public float m_fAttackSpeed;
    public float m_fMaxAttackSpeed;

    List<Item> m_Equipment = new List<Item>();
    public List<Item> m_Inventory = new List<Item>();



    public void Status(int Level, int MaxHP, int Str, int Def)
    {
        m_nLevel = Level;
        m_fMaxHp = m_fHp = MaxHP;
        m_fMaxStr = m_fStr = Str;
        m_fDef = Def;
    }

   public void potion()
    {
        m_fHp = m_fHp + m_fHp * 0.3f;
    }

    void LevelUp(Player player)
    {
        player.m_fMaxHp += 100;
        player.m_fExp = 0;

    }

    public void SetInventory(Item cItem)
    {
        m_Inventory.Add(cItem);
    }

    Item GetIventoryItem(int idx)
    {
        return m_Inventory[idx];
    }

    void DeleteInventory( Item cItem)
	{
        int i = 0;
         for(i=0; i<8; i++)
        {
           if( m_Inventory[i].m_strName==cItem.m_strName)
            {
                m_Inventory.Remove(m_Inventory[i]);
            }
        }
	}


    public void SetEquipment(Item cItem)
    {
        //m_Equipment[(int)cItem.m_eKind] = cItem;
       switch(cItem.m_eKind)
        {
            case Item.eKind.SWORD:
                StrEquipment(cItem);
                break;
            case Item.eKind.HELMET:
            case Item.eKind.ARMOR:
            case Item.eKind.GLOVES:
            case Item.eKind.SHOES:
                DefEquipment(cItem);
                break;
            case Item.eKind.NECKLACE:
            case Item.eKind.RING:
                AccEquipment(cItem);
                break;
        }
       
    }

    public void StrEquipment(Item cItem)
    {
        m_fStr += cItem.m_nFuctionF;
        m_fMaxCriticalChance += cItem.m_nFuctionS;
        m_fMaxAttackSpeed += cItem.m_nFuctionT;
    }

    public void DefEquipment(Item cItem)
    {
        m_fDef += cItem.m_nFuctionF;
        m_fHp = m_fMaxHp += cItem.m_nFuctionS;
        m_fMaxCriticalPower += cItem.m_nFuctionT;
    }
    public void AccEquipment(Item cItem)
    {
        m_fMaxCriticalChance += cItem.m_nFuctionF;
        m_fAvoid += cItem.m_nFuctionS;
    }

    public void RecoverHP(float val)
    {
        m_fHp += val;
        if (m_fHp > m_fMaxHp)
            m_fHp = m_fMaxHp;
    }

    public void RecoverySTR()
    {
        m_fStr = m_fMaxStr;
    }

    public bool Dead()
    {
        if (m_fHp <= 0)
            return true;
        else
            return false;
    }

 
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnCollisionEnter:" + collision.gameObject.name);
        if (collision.gameObject.tag == "Monster")
        {
            GameManager.GetInstance().Attack(m_fStr);
            Debug.Log("공격함 몬스터 체력:" + GameManager.GetInstance().m_cSkeleton.m_fHp);
        }
    }
}
