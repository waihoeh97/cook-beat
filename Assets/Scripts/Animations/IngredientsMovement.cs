using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsMovement : MonoBehaviour {

	public GameObject onion;
	public GameObject meat;
	public GameObject tomato;
	public GameObject tomato2;
	public GameObject meat2;


	public GameObject ingredient;
	public float t = 0;
	public Transform[] sequencePositions;
	public Vector3 targetPos;

	//subscribe to event
	private void OnEnable()
	{
		ingredientsTimeManager.OnEndSequence1 += OnEndSequenceFromTimer;
	}

	//unsubscribe to event
	private void OnDisable()
	{
		ingredientsTimeManager.OnEndSequence1 -= OnEndSequenceFromTimer;
	}

	void OnEndSequenceFromTimer(int curProgress) 
	{
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
		
			if(ingredientsTimeManager.swapIngredient == true)
			{
				meat.transform.position = Vector3.Lerp(meat.transform.position, targetPos, t * 0.5f);
			}
			if(ingredientsTimeManager.swapIngredient1 == true)
			{
				onion.transform.position = Vector3.Lerp(onion.transform.position, targetPos, t * 0.5f);
			}
			if(ingredientsTimeManager.swapIngredient2 == true)
			{
				tomato2.transform.position = Vector3.Lerp(tomato2.transform.position, targetPos, t * 0.5f);
			}
			if(ingredientsTimeManager.swapIngredient3 == true)
			{
				meat2.transform.position = Vector3.Lerp(meat2.transform.position, targetPos, t * 0.5f);
			}

			yield return null; // Skip this frame

			if (this.transform.position == targetPos) 
			{
				StopAllCoroutines();
			}
		}
	}
}
