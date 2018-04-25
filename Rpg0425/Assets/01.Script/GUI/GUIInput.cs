using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIInput : MonoBehaviour {

    public InputField Name;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InputName(Text text)
    {
        text.text = Name.text;
    }
}
