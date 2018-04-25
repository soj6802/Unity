using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    static GameManager m_cInstace = null;
    public Player player;
    public Monster monster;
    public Skeleton m_cSkeleton;
 //   public GUIManager guiManager;
  //  public ItemManager itemManager;
 //   public GameObject InventoryGui;
   // public Dynamic dynamic;
    public int m_nMaxMonster;

    // Use this for initialization
    void Start () {
        m_cInstace = this;
        monster.AddMonster(m_nMaxMonster);
        SetStatus();
    //    monster.m_Inventory=itemManager.m_ItemList;
       // InventoryGui.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        player.Dead();

	}

    void SetStatus()
    {
        player.Status(1, 1000, 100, 500);
        monster.Status( 1000, 100, 500);
        m_cSkeleton.Status(1000, 100, 500);
    }

    public void Attack( float demage)
    {
        m_cSkeleton.m_fHp = m_cSkeleton.m_fHp - demage;
    }

    public void MAttack(float demage)
    {
        player.m_fHp = player.m_fHp - demage;
    }


   public void Skill( int i)
    {
        int s;
        float str;
        if (i == 1)
        {
            //dynamic.KeyChk = false;
            str = player.m_fStr + player.m_fStr * 0.5f;
            for (s = 0; s < 3; s++)
            { Attack(str); }
          //  GameManager.GetInstance().guiManager.btn1.UseSkill();
            Debug.Log("공격함 몬스터 체력:" + monster.m_fHp);
        }
        if (i == 2)
        {
            str = player.m_fStr + player.m_fStr * 0.5f;
         //   GameManager.GetInstance().guiManager.btn2.UseSkill();
            Debug.Log("공격함 몬스터 체력:" + monster.m_fHp);
        }
        if (i == 3)
        {
            str = player.m_fStr + player.m_fStr * 0.5f;
            for (s = 0; s < 4; s++)
            {
                Attack(str);
            }
           // GameManager.GetInstance().guiManager.btn3.UseSkill();
            Debug.Log("공격함 몬스터 체력:" + monster.m_fHp);
        }
        if (i == 4)
        {
           str = player.m_fStr + player.m_fStr * 0.58f;
            for (s = 0; s < 10; s++)
            {
                Attack(str);
            }
         //   GameManager.GetInstance().guiManager.btn4.UseSkill();
            Debug.Log("공격함 몬스터 체력:" + monster.m_fHp);
        }
       
      
    }

    public void GetItem()
    {
        int i;
        for (int x = 0; x < 3; x++)
        {
            i = Random.Range(0, 7);
            GameManager.GetInstance().player.SetInventory(GameManager.GetInstance().monster.m_Inventory[i]);
        }

    }

    public static GameManager GetInstance()
    {
        return m_cInstace;
    }

}
