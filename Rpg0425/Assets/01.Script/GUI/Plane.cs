﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter:" + other.gameObject.name);
    }
}

