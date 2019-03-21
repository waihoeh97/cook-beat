using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour {

	SpriteRenderer rend;
	public GameObject obj1;
	public GameObject obj2;
	// Use this for initialization
	void Start () {
		rend =GetComponent<SpriteRenderer>();
		Color c = rend.material.color;
		c.a =0f;
		rend.material.color =c;
	}
	
	public IEnumerator FadeIn()
	{
		obj1.SetActive(true);
		obj2.SetActive(false);
		for(float f =0.05f;f<=1;f+=0.05f)
		{
			Color c= rend.material.color;
			c.a =f;
			rend.material.color =c;
			yield return new WaitForSeconds(0.01f);
		}
		for(float f =1f;f>=-0.05f;f-=0.05f)
		{
			Color c= rend.material.color;
			c.a =f;
			rend.material.color =c;
			yield return new WaitForSeconds(0.01f);

		}
		obj2.SetActive(true);
	}
//	public void FadeInZ()
//	{
//		StartCoroutine(FadeIn());
//	}

//	void Update()
//	{
//		if(Input.GetKeyDown(KeyCode.Z))
//		{
//			FadeInZ();
//		}
//	}
}
