using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public float t = 0;
    public Transform[] sequencePositions;
    public Vector3 targetPos;

    
    //subscribe to event
    private void OnEnable()
    {
        LevelTimeManager.OnEndSequence += OnEndSequenceFromTimer;
    }

    //unsubscribe to event
    private void OnDisable()
    {
        LevelTimeManager.OnEndSequence -= OnEndSequenceFromTimer;
    }

    void OnEndSequenceFromTimer(int curProgress) {

        targetPos = sequencePositions[curProgress].position;
        t = 0;
        LerpToTarget(targetPos);
    }

    public void LerpToTarget(Vector3 _targetPos)
    {
        targetPos = _targetPos;
        StopAllCoroutines();
        StartCoroutine(LerpToTargetRoutine());
    }

    IEnumerator LerpToTargetRoutine()
    {
        t = 0;

        while (true)
        {
            t += Time.deltaTime;
            t = Mathf.Clamp01(t);
			this.transform.position = Vector3.Lerp(this.transform.position, targetPos, t * 0.5f);

            yield return null; // Skip this frame

            if (this.transform.position == targetPos) StopAllCoroutines();
        }
    }
}
