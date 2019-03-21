using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimeManager : MonoBehaviour
{
    float startTime;
	private float timeNow;
    float[] marks = new float[] { 28f, 53f };
    int curProgress = 0;

    //creating delegate for this event
    public delegate void EndSequence( int currentProgress );
    public static event EndSequence OnEndSequence;


    // Update is called once per frame
    void Update()
    {
        timeNow += Time.deltaTime;

		if (curProgress == 0 && timeNow > marks[curProgress]) {
            curProgress++;
            OnEndSequence(this.curProgress);
        }
		else if (curProgress == 1 && timeNow > marks[curProgress]) {
            curProgress++;
            OnEndSequence(this.curProgress);
        }
    }    
}
