using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {
    public Slider HPBar;
    public Image HpFilter;

    void Start()
    {
        HpFilter.fillAmount = 1;
    }

  void Update()
    {
        HpFilter.fillAmount = 1 / GameManager.GetInstance().player.m_fMaxHp * GameManager.GetInstance().player.m_fHp;
    }
   
}
