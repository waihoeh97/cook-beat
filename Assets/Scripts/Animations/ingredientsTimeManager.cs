using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientsTimeManager : MonoBehaviour {

	public GameObject onion;
	public GameObject meat;
	public GameObject meat2;
	public GameObject tomato;
	public GameObject tomato2;

	public static bool swapIngredient;
	public static bool swapIngredient1;
	public static bool swapIngredient2;
	public static bool swapIngredient3;
	public static bool swapIngredient4;

	private float timeNow;
	float startTime;
	//private float timeLeft = 72.6f;
	float[] marks = new float[] { 6.0f, 14.0f, 22.0f, 30.0f};
	int curProgress = 0;

	//creating delegate for this event
	public delegate void EndSequence1( int currentProgress );
	public static event EndSequence1 OnEndSequence1;


	// Update is called once per frame
	void Update()
	{
		timeNow += Time.deltaTime;

//		Debug.Log(curProgress);

		if (curProgress == 0 && timeNow > marks[curProgress]) {
			tomato.SetActive(false);
			swapIngredient=true;
			curProgress++;
			OnEndSequence1(this.curProgress);
		}
		else if (curProgress == 1 && timeNow > marks[curProgress]) {
			meat.SetActive(false);
			swapIngredient=false;
			swapIngredient1=true;
			curProgress++;
			OnEndSequence1(this.curProgress);
		}
		else if (curProgress == 2 && timeNow > marks[curProgress]) {
			onion.SetActive(false);
			swapIngredient1=false;
			swapIngredient2=true;
			curProgress++;
			OnEndSequence1(this.curProgress);
		}
		else if (curProgress == 3 && timeNow > marks[curProgress]) {
			tomato2.SetActive(false);
			swapIngredient2=false;
			swapIngredient3=true;
			curProgress++;
			OnEndSequence1(this.curProgress);
		}
	}  
}
