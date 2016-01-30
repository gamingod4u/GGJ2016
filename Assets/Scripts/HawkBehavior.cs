using UnityEngine;
using System.Collections;

public class HawkBehavior : MonoBehaviour 
{
	public static HawkBehavior hawk;
	public float speed = 20;
	public int direction = 1;
	public bool leftSpwn = false;
	public bool canFly = false;


	public float cooldown = 3;
	public float timer = 0;

	// Use this for initialization
	void Start () 
	{
		
		hawk = this;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (!leftSpwn) {
			direction = 1;
			gameObject.transform.eulerAngles = new Vector3 (0, 0, 0);
		} else {
			direction = 1;
			gameObject.transform.eulerAngles = new Vector3 (0, 180, 0);
		}

		if (timer < cooldown)
			timer += Time.deltaTime;
		else
			canFly = true;

		if (canFly) {
			//gameObject.transform.Translate ((speed * Time.deltaTime) * direction, 0, 0);
			gameObject.transform.Translate ((Vector3.right * (speed * Time.deltaTime) * direction), Space.Self);

			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0);
		} 

		


	}


	public void setSpeed(float value){speed = value;}
	public float getSpeed(){return speed;}
}
