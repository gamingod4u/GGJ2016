using UnityEngine;
using System.Collections;

public class MateBehavior : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{

		Debug.Log ("We were hit");
		if (coll.transform.name == "Hawk") 
		{
			gameObject.transform.parent = coll.transform;
		}
	}
}
