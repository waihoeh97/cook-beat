using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraColor : MonoBehaviour {

	public SimpleBeatDetection beatProcessor;

	//float bpm =93;
	//float songPos;
	public static float songPosInBeats;
	//float secPerBeat;
	//float dspTimeSong;

	public static bool onTheBeat;

	public static float beatCurPos;

//	public float[] curPos;

	public int size=40;
	List<float> myList = new List<float>();

	void Start () {
		beatProcessor.OnBeat += OnBeat;
		//secPerBeat = 60f / bpm;
		//dspTimeSong = (float) AudioSettings.dspTime;

//		GameController.Load();
//
	}

	void Update () 
	{
	
		//songPos = (float) (AudioSettings.dspTime - dspTimeSong);

//		if(onTheBeat==true)
//		{
//			GameController.Save();
//			songPosInBeats = songPos / secPerBeat;
//			//storeValue(songPosInBeats);
//			onTheBeat=false;
//
//
//		}
	}
	public void storeValue(float songPosInBeatsZ)
	{

		myList.Add(songPosInBeatsZ);
		foreach(float data in myList)
		{
			Debug.Log(data);
		}
	
	}

	public static int counter;

	public void OnBeat()
	{
		
	
//			songPosInBeats = songPos / secPerBeat;
//			GameController.Save();
//	
	
	//	Debug.Log(songPosInBeats);

	}
}

