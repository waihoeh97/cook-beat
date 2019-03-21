using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SpriteRenderer))]
public class SaltShakerInput : MonoBehaviour {

	[SerializeField]MeshRenderer target;
	//SpriteRenderer srend;

	void Awake ()
	{
		//srend = GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown ()
	{
		Debug.Log("Tap Salt Shaker");
	}
}
