using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToEnd : MonoBehaviour {

	public SceneManagerScript sceneManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				sceneManager.ToMainMenu();
			}
		}
	}
}
