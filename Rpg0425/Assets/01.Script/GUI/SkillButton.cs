using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Image skillFilter;
    public Text coolTimeCount;
    public string SkillName;

    public float coolTime ;

    private float currentCoolTime;

    public bool SkillStatus = true;

    void start()
    {
        SkillName = coolTimeCount.text;
        skillFilter.fillAmount = 0;
    }

 
    public void UseSkill()
    {
        if (SkillStatus==true)
        {
            SkillStatus = false;
            Debug.Log("스킬사용");
            skillFilter.fillAmount = 1;
            StartCoroutine("Cooltime");

            currentCoolTime = coolTime;
            coolTimeCount.text = "" + currentCoolTime;

            StartCoroutine("CoolTimeCounter");

        }
        else
        {
            Debug.Log("아직 스킬을 사용할 수 없습니다.");
        }
    }


    IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;
            yield return null;
        }

        SkillStatus = true;
        yield break;
    }

    IEnumerator CoolTimeCounter()
    {
        while(currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);

            currentCoolTime -= 1.0f;
            coolTimeCount.text = "" + currentCoolTime;
        }
        coolTimeCount.text = SkillName;
        yield break;
    }
}
