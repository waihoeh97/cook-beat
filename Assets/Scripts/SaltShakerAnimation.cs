using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltShakerAnimation : MonoBehaviour {

	public Animator saltAnim;
	public GameObject saltShaker;

	// Use this for initialization
	void Start () {
		
	}

	public void OnButtonTap()
	{
		if (saltShaker.activeSelf == true)
		{
			Debug.Log("PlayAnimation");
			saltAnim.SetBool("shake", true);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
