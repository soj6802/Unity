using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour {

    Animator animator;
    public Transform m_Target;
    public float m_fMinDist = 1000;
    NavMeshAgent m_cNavMeshAgent;
    

    public float m_fSpeed;
    public float m_fHp;
    public float m_fStr;
    public float m_fDef;
    public float m_fMaxHp;
    public int m_nLevel;
    public float m_fExp;
    public float m_fCriticalPower;
    public float m_fCriticalChance;
    public float m_fMaxCriticalPower;
    public float m_fMaxCriticalChance;
    public float m_fAvoid;
    public int m_nGold;

    public List<Item> m_Inventory = new List<Item>();
    public GameObject monsterPrefab;
    public List<GameObject> m_listMonster = new List<GameObject>();
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        m_cNavMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }
	
    void Awake()
    {
        m_Target = GameObject.Find("Player").transform;
    }
	// Update is called once per frame
	void Update () {
        MoveTarget();
    }

    public void AddMonster(int i)//몬스터 생성
    {
        for (int n = 0; n < i ; n++)
        {
            GameObject mon = Instantiate(monsterPrefab);
            m_listMonster.Add(mon);
        }
    }
    public void DeleteMonster(GameObject mon)
    {
        Destroy(mon);
        m_listMonster.Remove(mon);
    }

    public void Status(int MaxHP, int Str, int Def)
    {
        m_fMaxHp = m_fHp = MaxHP;
        m_fStr = Str;
        m_fDef = Def;
    }

    public bool Dead()
    {
        if (m_fHp <= 0)
        {
            return true;
        }
        return false;
    }

    public bool StateChk()
    {
        if (m_fHp <= 0)
        {
            return false;
        }
        return true;
    }



    //public void SetInventory()
    //{
    //    m_Inventory.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.SWORD));
    //    m_Inventory.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.HELMET));
    //    m_Inventory.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.ARMOR));
    //    m_Inventory.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.GLOVES));
    //    m_Inventory.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.SHOES));
    //    m_Inventory.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.HPPOTION));
    //    m_Inventory.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.NECKLACE));
    //    m_Inventory.Add(GameManager.GetInstance().itemManager.GetItem((int)Item.eKind.RING));
    //}

    public Item GetIventoryItem(int idx)
    {
        
        return m_Inventory[idx];
    }


    public void MoveTarget()
    {
        //m_Target = GameObject.Find("Player").transform;
        //m_cNavMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        if (m_fMinDist >= Vector3.Distance(m_Target.position, transform.position))
        {
            m_cNavMeshAgent.destination = m_Target.position;
        }
        else
        {
            m_fSpeed = 0;
            animator.SetBool("Attack", true);
        }
    }

    private void OnDestroy()
    {
        ReleaseMonster();
    }

    public void ReleaseMonster()
    {
        for (int i = 0; i < m_listMonster.Count; i++)
        {
            Destroy(m_listMonster[i]);
            m_listMonster.Remove(m_listMonster[i]);
        }
    }
}
