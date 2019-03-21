using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour {

	public GameObject musicNote;

	public GameObject smokeEffect;
	public GameObject fireEffect;
	public GameObject normalfireEffect;
	public GameObject knife;
	public GameObject pan;
	public GameObject saltShaker;

	public Animator tongsAnim;
	public Animator knifeAnim;
	public Animator saltAnim;

	public CameraShake cameraShake;

	// the current position of the song (in seconds)
	public float songPos;

	// the current position of the song (in beats)
	public float songPosInBeats;

	// the duration of the beat
	public float secPerBeat;

	// how much time (in seconds) has passed since the song started
	public float dspTimeSong;

	private float bpm = 76.5f;

	public bool onBeat;
	public bool canTap;

	public ColorChange colorChanger;
	public Color lerpColor = Color.black;

//	public Image saltIMG;
//	public Button saltBtn;

	public GameObject[] ingredientStates;

	public Image urTurnUI;
	public Image followUI;

	// keep all the position-in-beats of notes in the song
//	float[] notes = {
//		
//					};

	float[] playerInput = {
		// Knife
		6.0f, 6.5f, 7.0f, 7.5f, 8.0f, 
		14.0f, 14.5f, 15.0f, 15.5f, 16.0f,
		22.0f, 22.5f, 23.0f, 23.5f, 24.0f,
		30.0f, 30.5f, 31.0f, 31.5f, 32.0f,

		// Strainer
		34.5f, 36.5f, 38.5f, 40.5f, 42.5f, 44.5f, 46.5f, 48.5f, 50.5f, 52.5f, 54.5f, 56.5f, 58.5f, 60.5f, 62.5f,

		// Pan start
		67.5f, 71.5f, 75.5f, 79.5f,
		//83.5f, 85.5f, 87.5f, 89.5f, 91.5f, 93.5f, 95.5f old
		83.5f, 87.5f, 91.5f, 95.5f //new
	};

	// the index of the next note to be spawned
	int nextIndex = 0;
	int nextIndex1 =0;
	int nextIndex2 =0;
	int nextIndex4 =0;
	int nextIndex3 =0;

	public float timer;
	public int[] indexArray;

	// Use this for initialization
	void Start () 
	{
		
		urTurnUI.enabled = false;
		followUI.enabled = true;

		// Calculate how many seconds is one beat
		secPerBeat = 60f / bpm;

		// Record the time when the song starts
		dspTimeSong = (float) AudioSettings.dspTime;

		// Start the song
		GetComponent<AudioSource>().Play();

		//smokeEffect.SetActive(false);
		//fireEffect.SetActive(false);
		//saltShaker.SetActive(false);
		//saltBtn.gameObject.SetActive(false);
	}

	void ColorChange ()
	{
		lerpColor = Color.Lerp (Color.black, Color.red, Mathf.PingPong (Time.time, 1));
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Calculate the position in seconds
		songPos = (float) (AudioSettings.dspTime - dspTimeSong);

		// Calculate the position in beats
		songPosInBeats = songPos / secPerBeat;
		if (nextIndex3 < playerInput.Length-0.5f && playerInput[nextIndex3]-0.5f < songPosInBeats)
		{
		//	uTurnUI.enabled=true;
			nextIndex3++;
		}

		// UI Your Turn Indicator
		if(songPosInBeats>0f&&songPosInBeats<=6.0f||songPosInBeats>playerInput[4]+0.1f&&songPosInBeats<playerInput[5]-0.1f||songPosInBeats>=playerInput[9]+0.1f&&songPosInBeats<=playerInput[10]-0.1f||
			songPosInBeats>playerInput[14]+0.1f&&songPosInBeats<playerInput[15]-0.1f||songPosInBeats>playerInput[19]+0.1f&& songPosInBeats<playerInput[20]-0.1f||songPosInBeats>=playerInput[20]+0.1f&& songPosInBeats<=playerInput[21]-0.1f||
			songPosInBeats>=playerInput[21]+0.1f&& songPosInBeats<=playerInput[22]-0.1f||songPosInBeats>=playerInput[22]+0.1f&& songPosInBeats<=playerInput[23]-0.1f||songPosInBeats>=playerInput[23]+0.1f&& songPosInBeats<=playerInput[24]-0.1f
			||songPosInBeats>=playerInput[24]+0.1f&& songPosInBeats<=playerInput[25]-0.1f||songPosInBeats>=playerInput[25]+0.1f&& songPosInBeats<=playerInput[26]-0.1f||songPosInBeats>=playerInput[26]+0.1f&& songPosInBeats<=playerInput[27]-0.1f
			||songPosInBeats>=playerInput[27]+0.1f&& songPosInBeats<=playerInput[28]-0.1f||songPosInBeats>=playerInput[28]+0.1f&& songPosInBeats<=playerInput[29]-0.1f||songPosInBeats>=playerInput[29]+0.1f&& songPosInBeats<=playerInput[30]-0.1f
			||songPosInBeats>=playerInput[30]+0.1f&& songPosInBeats<=playerInput[31]-0.1f||songPosInBeats>=playerInput[31]+0.1f&& songPosInBeats<=playerInput[32]-0.1f||songPosInBeats>=playerInput[32]+0.1f&& songPosInBeats<=playerInput[33]-0.1f
			||songPosInBeats>=playerInput[33]+0.1f&& songPosInBeats<=playerInput[34]-0.1f||songPosInBeats>=playerInput[34]+0.1f&& songPosInBeats<=playerInput[35]-0.1f||songPosInBeats>=playerInput[35]+0.1f&& songPosInBeats<=playerInput[36]-0.1f
			||songPosInBeats>=playerInput[36]+0.1f&& songPosInBeats<=playerInput[37]-0.1f||songPosInBeats>=playerInput[37]+0.1f&& songPosInBeats<=playerInput[38]-0.1f||songPosInBeats>=playerInput[39]+0.1f&& songPosInBeats<=playerInput[40]-0.1f
			||songPosInBeats>=playerInput[40]+0.1f&& songPosInBeats<=playerInput[41]-0.1f||songPosInBeats>=playerInput[41]+0.1f&& songPosInBeats<=playerInput[42]-0.1f)
		{
			urTurnUI.enabled = false;
			followUI.enabled = true;
		}

		for(int i=0;i<playerInput.GetLength(0);i++)
		{
			if(songPosInBeats>playerInput[i]-0.5f&&songPosInBeats<playerInput[i])
			{
				urTurnUI.enabled = true;
				followUI.enabled = false;
			}
		}

		if (nextIndex2 < playerInput.Length-0.25f && playerInput[nextIndex2]-0.25f < songPosInBeats)
		{
			canTap=true;
			//fireEffect.SetActive(true);
			//normalfireEffect.SetActive(false);
			colorChanger.StartCoroutine ("ChangeColor");

			(knife.GetComponent("Halo") as Behaviour).enabled = true;
	
			pan.transform.position= new Vector3(pan.transform.position.x-0.1f,pan.transform.position.y,pan.transform.position.z);
		
//			if(nextIndex2==22||nextIndex2==23||nextIndex2==24||nextIndex2==30||nextIndex2==31||nextIndex2==32||nextIndex2==38||nextIndex2==39||nextIndex2==40)
//			{
//				//saltIMG.enabled=true;
//				saltShaker.SetActive(true);
//				//saltBtn.gameObject.SetActive(true);
//			}
//			else
//			{
//				//saltIMG.enabled=false;
//				saltShaker.SetActive(false);
//				//saltBtn.gameObject.SetActive(false);
//			}
			nextIndex2++;
		}

		if (nextIndex1 < playerInput.Length-0.35f && playerInput[nextIndex1]-0.35f < songPosInBeats)
		{
			//ssmokeEffect.SetActive(true);
			pan.transform.position= new Vector3(pan.transform.position.x+0.2f,pan.transform.position.y,pan.transform.position.z);
		
			nextIndex1++;
			//test
//			tongsAnim.SetBool("tongs",true);
//			knifeAnim.SetBool("cutting", true);
		}

		// Main
		if (nextIndex < playerInput.Length && playerInput[nextIndex] < songPosInBeats)
		{
			canTap = true;
			pan.transform.position= new Vector3(pan.transform.position.x-0.1f,pan.transform.position.y,pan.transform.position.z);
			pan.transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (-100f, 0f, 0f), Time.deltaTime * 180f);
		
			for(int i=0;i<ingredientStates.GetLength(0);i++)
			{
				if(nextIndex==i)
				{
//					Debug.Log(i);
					ingredientStates[i].SetActive(false);
				}
			}
			
			//Instantiate (musicNote);
//			if (songPos <= 26f)
//			{
//				SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_KNIFE);
//			}
//			if (songPos >= 26f && songPos <= 50f)
//			{
//				SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_DRAIN);
//			}
//			if (songPos >= 50f)
//			{
//				SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_FRY);
//			}

			//smokeEffect.SetActive(false);
			//fireEffect.SetActive(false);
			//normalfireEffect.SetActive(true);
			(knife.GetComponent("Halo") as Behaviour).enabled = false;
//			tongsAnim.SetBool("tongs",false);
//			knifeAnim.SetBool("cutting", false);

			nextIndex++;
		}

		if (nextIndex4 < playerInput.Length+0.2f && playerInput[nextIndex4]+0.2f < songPosInBeats)
		{
			canTap = false;
			pan.transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (-90f, 0f, 0f), Time.deltaTime * 180f);
			nextIndex4++;
		}
	
	}
}
