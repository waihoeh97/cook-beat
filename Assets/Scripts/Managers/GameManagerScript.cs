using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour 
{
	private static GameManagerScript mInstance;

	public static GameManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject[] tempObjectList = GameObject.FindGameObjectsWithTag("GameManager");

				if(tempObjectList.Length > 1)
				{
					Debug.LogError("You have more than 1 Game Manager in the Scene");
				}
				else if(tempObjectList.Length == 0)
				{
					GameObject obj = new GameObject("_GameManager");
					mInstance = obj.AddComponent<GameManagerScript>();
					obj.tag = "GameManager";
				}
				else
				{
					if(tempObjectList[0] != null)
					{
						Debug.Log("Found a game manager");
						mInstance = tempObjectList[0].GetComponent<GameManagerScript>();
					}
				}
			}
			return mInstance;
		}
	}

	public SongManager songManager;
	public Animator knife;
	public Animator tongs;

	// Use this for initialization
	void Start () 
	{
		Scene curScene = SceneManager.GetActiveScene();
		Debug.Log(curScene.buildIndex);
		if(curScene.buildIndex == 0)
		{
			SoundManagerScript.Instance.PlayBGM(SoundManagerScript.AudioClipID.BGM_MAINMENU);
		}

		ObjectPoolManagerScript.Instance.InitializeObjectPools();
	}

	public void CurrentPartCheck ()
	{
		if (songManager.songPos <= 26f)
		{
			knife.Play("KnifeCutting");
			SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_KNIFE);
		}
		if (songManager.songPos >= 26f && songManager.songPos <= 50f)
		{
			tongs.Play("TongsAction");
			SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_DRAIN);
		}
		if (songManager.songPos >= 50f)
		{
			SoundManagerScript.Instance.PlaySFX(SoundManagerScript.AudioClipID.SFX_FRY);
		}
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

}
