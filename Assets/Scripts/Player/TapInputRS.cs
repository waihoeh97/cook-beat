using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TapInputRS : MonoBehaviour {

	public SongManager songManager;
	public ColorChangeInput colorChanger;
	public CameraShake cameraShake;

	public static bool inputCheck;

	public static bool value;
	public float timer;
	bool runTimerZ;

	public fadeIn fadeInZ;
	public FadeOut fadeOutZ;
	public static float score;

	// Use this for initialization
	void Start () 
	{
		fadeInZ = FindObjectOfType<fadeIn>();
		fadeOutZ = FindObjectOfType<FadeOut>();
		colorChanger = FindObjectOfType<ColorChangeInput>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(songManager.canTap);
		if (Input.touchCount > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				GameManagerScript.Instance.CurrentPartCheck ();
				// Check whether input is correct or not
				if (songManager.canTap == true)
				{
					// can
					score++;
					StartCoroutine(fadeInZ.FadeIn());
					StartCoroutine(colorChanger.ChangeColorCorrect());
					songManager.canTap = false;
				}
				else
				{
					// cannot
					score-=0.5f;
					StartCoroutine(fadeOutZ.FadeInG());
					StartCoroutine(cameraShake.Shake(.3f,.01f,false));
					colorChanger.StartCoroutine("ChangeColorIncorrect");
					SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_KNIFEMISS);
					songManager.canTap = false;
				}
			}
		}
	
		// For testing purposes on PC
		if(Input.GetKeyDown(KeyCode.A))
		{
			GameManagerScript.Instance.CurrentPartCheck ();
			// Check whether input is correct or not
			if (songManager.canTap == true)
			{
				score++;
				StartCoroutine(fadeInZ.FadeIn());
				StartCoroutine(colorChanger.ChangeColorCorrect());
				songManager.canTap = false;
			}
			else
			{
				score-=0.5f;
				StartCoroutine(fadeOutZ.FadeInG());
				StartCoroutine(cameraShake.Shake(.3f,.01f,false));
				colorChanger.StartCoroutine("ChangeColorIncorrect");
				SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_KNIFEMISS);
				songManager.canTap = false;
			}
		}
	}
}
