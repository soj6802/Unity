using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    private Transform tr;
    Animator animator;
    public float m_fSpeed;
    public float m_fRotSpeed;
    //public Transform Target;
    public bool KeyChk;

    // Use this for initialization

    void Start()
    {
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        //KeyChk = false;

    }



    // Update is called once per frame
    void Update()
    {
        float fTime = Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("SpaChk", true);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("SpaChk", false);
        }
        if (Input.GetKey(KeyCode.F))
        {
            animator.SetBool("FChk", true);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("FChk", false);
        }


        tr.Rotate(Vector3.up * Time.deltaTime * m_fRotSpeed * Input.GetAxis("Mouse X"));

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("WChk", true);
            tr.Translate(Vector3.forward * m_fSpeed * fTime);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("WChk", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("WChk", true);
            tr.Translate(Vector3.back * m_fSpeed * fTime);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("WChk", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("DChk", true);
            tr.Translate(Vector3.right * m_fSpeed * fTime);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("DChk", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("AChk", true);
            tr.Translate(Vector3.left * m_fSpeed * fTime);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("AChk", false);
        }


        if (Input.GetMouseButtonDown(0))
        {
            //GameManager.GetInstance().Attack(GameManager.GetInstance().player.m_fStr);
            //Debug.Log("공격함 몬스터 체력:" + GameManager.GetInstance().monster.m_fHp);
        }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //  //  if (GameManager.GetInstance().guiManager.btn1.SkillStatus == true)
        //    {

        //        if (KeyChk == true)
        //        {
        //            GameManager.GetInstance().Skill(1);
        //        }
        //        //animator.SetBool("AttackChk", true);
        //       // GameManager.GetInstance().guiManager.btn1.UseSkill();
        //    }
        //    else
        //    {
        //        // animator.SetBool("AttackChk", false);
        //        KeyChk = false;
        //    }

        //}
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.GetInstance().Skill(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.GetInstance().Skill(3);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.GetInstance().Skill(4);

        }
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    if (GameManager.GetInstance().InventoryGui.activeSelf == true)
        //    {
        //        GameManager.GetInstance().InventoryGui.SetActive(false);
        //    }
        //    else
        //        GameManager.GetInstance().InventoryGui.SetActive(true);
        //}
        if (Input.GetKey(KeyCode.Alpha1))
        {
            GameManager.GetInstance().player.potion();
        }

    }
   
    //private void OnCollisionStay(Collision collision)
    //{
    //    KeyChk = true;

    //    if (collision.collider.tag == "Monster" && GameManager.GetInstance().monster.Dead() == true)
    //    {
    //        GameManager.GetInstance().player.SetInventory(GameManager.GetInstance().monster.GetIventoryItem(Random.Range(0, 7)));
    //        Debug.Log("아이템획득" + GameManager.GetInstance().player.m_Inventory[0].m_eKind);
    //        GameManager.GetInstance().player.SetEquipment(GameManager.GetInstance().player.m_Inventory[0]);
    //        GameManager.GetInstance().monster.DeleteMonster(collision.gameObject);
    //    }
    //}
}
