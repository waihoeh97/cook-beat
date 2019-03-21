using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapInput : MonoBehaviour {

	Animator anim;
	public bool touch;

	void Awake ()
	{
		touch = false;
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.touchCount > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				touch = true;
				anim.Play("KnifeAnimation(Temp)");
				SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_KNIFE);
			}
		}
		//Debug.Log (touch);
	}

	// animation
	void StopTap ()
	{
		touch = false;
		anim.SetBool("tap", false);
	}
}
