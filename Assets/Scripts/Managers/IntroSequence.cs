using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequence : MonoBehaviour {

    int curIndex = 0;
    public GameObject[] GO;

    public int CurrentIndex
    {
        get
        {
            return curIndex;
        }
        set
        {
            if (GO[curIndex] != null)
            {
                //set the current active object to inactive, before replacing it
                GameObject activeObject = GO[curIndex];
                activeObject.SetActive(false);
            }

            if (value < 0)
                curIndex = GO.Length - 1;
            else if (value > GO.Length - 1)
                curIndex = 0;
            else
                curIndex = value;
            if (GO[curIndex] != null)
            {
                GameObject activeObject = GO[curIndex];
                activeObject.SetActive(true);
            }
        }
    }

    public void Next(int direction)
    {
        if (direction == 0)
            CurrentIndex++;
        else
            CurrentIndex--;
    }

    // Use this for initialization
    void Awake () {
        if (GO.Length > 0)
        {
            for (int i = 1; i < GO.Length; ++i)
            {
                GO[i].SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
