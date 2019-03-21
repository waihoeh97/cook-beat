using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollision : MonoBehaviour 
{
	
	public GameObject note;
	public GameObject otherObj;

	public Material[] mal;
	Renderer rend;

	public float timerX;
	public float randtime;

	public bool reachedTriggerPoint;
	public AudioProcessor now;
	bool chgColor;
	public int ascendingNum;

	void Start()
	{
//		rend= GetComponent<Renderer>();
//		rend.enabled=true;
//		now= FindObjectOfType<AudioProcessor>();
	
	}

	void Update()
	{
//		
//		timerX+=Time.deltaTime;
//	
//		if(timerX>=0.4f)
//		{
//			transform.position+=new Vector3(-1f,0f,0f);
//			timerX=0f;
//		}
	
//		if(now.changeCol==false)
//		{
//			Debug.Log("noBeat");
//			rend.sharedMaterial = mal[0];
//		}
//		else{
//			rend.sharedMaterial = mal[1];
//		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			rend.sharedMaterial = mal[1];
		}
		if(Input.GetKeyDown(KeyCode.A )&& reachedTriggerPoint==true)
		{
			Debug.LogWarning("Perfect!");
			note.SetActive(false);
			reachedTriggerPoint=false;
		}


	
	}

	void OnTriggerEnter(Collider col)
	{
		
		if(col.gameObject.tag=="TriggerPoint")
		{
				reachedTriggerPoint=true;
		}
	

	
	}
//	public void changeOBJColor()
//	{
//		
//		rend= GetComponent<Renderer>();
//		rend.enabled=true;
//		now= FindObjectOfType<AudioProcessor>();
//		chgColor=true;
//		if(rend.sharedMaterial==mal[1]&&chgColor==true)
//		{
//			
//			rend.sharedMaterial=mal[0];
//			Debug.Log("Cur Material=="+rend.sharedMaterial);
//			chgColor=false;
//		}
//	
//		else if(rend.sharedMaterial==mal[0]&&chgColor==true)
//		{
//			
//			rend.sharedMaterial = mal[1];
//			Debug.Log("Cur Material=="+rend.sharedMaterial);
//			now.changeCol=false;
//		}
//
//	}

	void OnTriggerExit(Collider col)
	{

		if(col.gameObject.tag=="TriggerPoint")
		{
			reachedTriggerPoint=false;
			Debug.LogError("noob!");
			note.SetActive(false);

		}



	}
//	public void noteMoving()
//	{
//		this.gameObject.transform.position+=new Vector3(-5f,0f,0f);
//		Debug.Log(transform.position);
//	}
	public void changeColor()
	{

			rend= GetComponent<Renderer>();
			rend.enabled=true;
			now= FindObjectOfType<AudioProcessor>();
			rend.sharedMaterial=mal[ascendingNum];
			ascendingNum++;
		
		if(ascendingNum==3)
		{
			
			 ascendingNum = 0;
		}


			
			
	}


}
