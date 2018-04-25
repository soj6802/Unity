using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour {

    public Text time;
    public float m_fTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(m_fTime>0f)
        {
            m_fTime -= Time.deltaTime;
            time.text =(int)m_fTime/60 +":" + (int)m_fTime%60;
        }
	}
}
