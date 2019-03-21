using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
		Scene currentScene = SceneManager.GetActiveScene ();

		if (currentScene.buildIndex == 0)
		{
			SoundManagerScript.Instance.PlayBGM(SoundManagerScript.AudioClipID.BGM_MAINMENU);
		}
		else if (currentScene.buildIndex == 1)
		{
			SoundManagerScript.Instance.PlayBGM(SoundManagerScript.AudioClipID.BGM_INTRO);
		}
		else if (currentScene.buildIndex == 3)
		{
			SoundManagerScript.Instance.PlayBGM(SoundManagerScript.AudioClipID.BGM_ENDING);
		}
		else
		{
			SoundManagerScript.Instance.StopBGM();
		}
	}

	public void ToMainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void ToIntro()
	{
		SceneManager.LoadScene(1);
	}
	//replay btn
	public void ToMainCourse()
	{
		SceneManager.LoadScene(2);
	}

	public void ToResult()
	{
		Debug.Log(TapInputRS.score);
		SceneManager.LoadScene(3);
	}


	public void ToEnd()
	{
        Application.Quit();
	}
    
	// Update is called once per frame
	void Update () {

    }
}
