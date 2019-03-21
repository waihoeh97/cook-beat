using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeInput : MonoBehaviour {

	//public Image tapIndicator;
	public GameObject tapIndicatorGood;
	public GameObject tapIndicatorMad;
	public GameObject tapIndicatorNeutral;

//	Color startColor = Color.black;
//	Color endColor = Color.green;
//	Color wrongColor = Color.red;

	public TapInputRS tapInput;
	public SongManager songManager;
	public float timer;

	void Start ()
	{
		tapInput = FindObjectOfType<TapInputRS>();
		songManager = FindObjectOfType<SongManager>();
		//tapIndicator.GetComponent<Image>().color = startColor;
		tapIndicatorNeutral.SetActive(true);
		tapIndicatorGood.SetActive(false);
		tapIndicatorMad.SetActive(false);
	}

	public IEnumerator ChangeColorCorrect ()
	{
		tapIndicatorGood.SetActive(true);
		tapIndicatorMad.SetActive(false);
		tapIndicatorNeutral.SetActive(false);
		//tapIndicator.GetComponent<Image>().color = endColor;
		yield return new WaitForSeconds (0.1f);
		tapIndicatorGood.SetActive(false);
		tapIndicatorMad.SetActive(false);
		tapIndicatorNeutral.SetActive(true);
		//tapIndicator.GetComponent<Image>().color = startColor;
		yield return null;
	}

	public IEnumerator ChangeColorIncorrect ()
	{
		tapIndicatorGood.SetActive(false);
		tapIndicatorMad.SetActive(true);
		tapIndicatorNeutral.SetActive(false);
	
		yield return new WaitForSeconds (0.2f);

		tapIndicatorGood.SetActive(false);
		tapIndicatorMad.SetActive(false);
		tapIndicatorNeutral.SetActive(true);

		yield return null;
	}

}