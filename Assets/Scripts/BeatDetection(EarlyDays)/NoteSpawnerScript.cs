using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

//		GameObject obj = ObjectPoolManagerScript.Instance.GetPooledObject(PooledObjects.note);
//		if(obj!=null)
//		{
//			obj.transform.position= new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
//			obj.SetActive(true);
//		}
	}
	public void createNote()
	{
		GameObject obj = ObjectPoolManagerScript.Instance.GetPooledObject(PooledObjects.note);
		if(obj!=null)
		{
			obj.transform.position= new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
			obj.SetActive(true);

		}
	}
}
