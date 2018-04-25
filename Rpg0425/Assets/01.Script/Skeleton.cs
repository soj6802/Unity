using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour {
    Animator animator;
    public Transform m_Target;
    NavMeshAgent m_cNavMeshAgent;

    public float m_fSpeed = 10;
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
    // Use this for initialization

    void Start () {
        animator = GetComponent<Animator>();
        m_cNavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator.SetBool("DeadChk", false);
        animator.SetBool("WalkChk", true);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTarget();
        
    }
    float dist;
    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), string.Format("{0}", dist));
    }

    public void MoveTarget()
    {
        dist = Vector3.Distance(m_Target.position, transform.position);
        if (m_cNavMeshAgent.stoppingDistance <= dist)
        {
            m_cNavMeshAgent.destination = m_Target.position;
            animator.SetBool("WalkChk", true);
            animator.SetBool("AttackChk", false);
            //animator.SetBool("DistanceChk", false);
        }
        else
        {
            m_fSpeed = 0;
            //animator.SetBool("DistanceChk", true);
            animator.SetBool("WalkChk", false);
            animator.SetBool("AttackChk", true);
        }
    }

    public void Status(int MaxHP, int Str, int Def)
    {
        m_fMaxHp = m_fHp = MaxHP;
        m_fStr = Str;
        m_fDef = Def;
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnCollisionEnter:" + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GetInstance().MAttack(m_fStr);
            Debug.Log("공격함 플레이어 체력:" + GameManager.GetInstance().player.m_fHp);
        }
    }
}
