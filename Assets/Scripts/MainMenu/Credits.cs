﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

	public GameObject credits;

	// Use this for initialization
	void Start () {
		credits.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnableCredits ()
	{
		credits.SetActive(true);
	}

	public void DisableCredits ()
	{
		credits.SetActive(false);
	}
}
