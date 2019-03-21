using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPMTimer : MonoBehaviour {

	public SceneManagerScript sceneManager;

	float musicTime = 85f;
	float bpm = 94;

	public float totalTime;

	// Use this for initialization
	void Start () {

		totalTime = musicTime / 60f * bpm;
	}
	
	// Update is called once per frame
	void Update () {

		totalTime -= (bpm / 60f) * Time.deltaTime;

		//timerText.text = seconds;

		if (totalTime <= 10f)
		{
			sceneManager.ToResult();
		}
	}
}
