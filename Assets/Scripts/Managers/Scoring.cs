using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {

	public GameObject end1;
	public GameObject end2;
	public GameObject end3;

	public GameObject board;
	public GameObject homeBtn;
	public GameObject retryBtn;

	public GameObject[] gameObjects;
	int j;

	void Start () {
		end1.SetActive(false);
		end2.SetActive(false);
		end3.SetActive(false);

		board.SetActive(false);
		homeBtn.SetActive(false);
		retryBtn.SetActive(false);
	}

	IEnumerator Result ()
	{
		yield return null;

		if(TapInputRS.score<=17)
		{
			end3.SetActive(true);
			yield return new WaitForSeconds (3.0f);
			board.SetActive(true);
			homeBtn.SetActive(true);
			retryBtn.SetActive(true);
			for(int i=0;i<gameObjects.GetLength(0);i++)
			{
				if(i==0||i==3||i==6)
				{
					j=i;
					gameObjects[j].SetActive(true);
				}
			}
		}
		else if(TapInputRS.score>17&&TapInputRS.score<=26)
		{
			end2.SetActive(true);
			yield return new WaitForSeconds (3.0f);
			board.SetActive(true);
			homeBtn.SetActive(true);
			retryBtn.SetActive(true);
			for(int i=0;i<gameObjects.GetLength(0);i++)
			{
				if(i==0||i==1||i==4||i==7)
				{
					j=i;
					gameObjects[j].SetActive(true);
				}
			}
		}
		else if(TapInputRS.score>26)
		{
			end1.SetActive(true);
			yield return new WaitForSeconds (3.0f);
			board.SetActive(true);
			homeBtn.SetActive(true);
			retryBtn.SetActive(true);
			for(int i=0;i<gameObjects.GetLength(0);i++)
			{
				if(i==0||i==1||i==2||i==5||i==8)
				{
					j=i;
					gameObjects[j].SetActive(true);
				}
			}
		}
		TapInputRS.score=0;
		Debug.LogError(TapInputRS.score);
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(Result());	
	}
}
