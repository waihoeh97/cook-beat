using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {

	public Image tapIndicator;

	Color startColor = Color.white;
	Color endColor = Color.green;

	void Start ()
	{
		tapIndicator.GetComponent<Image>().color = startColor;
	}

	public IEnumerator ChangeColor ()
	{
		tapIndicator.GetComponent<Image>().color = endColor;
		yield return new WaitForSeconds (0.1f);
		tapIndicator.GetComponent<Image>().color = startColor;
		yield return null;
	}
}
