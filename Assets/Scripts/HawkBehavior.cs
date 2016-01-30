using UnityEngine;
using System.Collections;

public class HawkBehavior : MonoBehaviour 
{
	public delegate void OnPlayerHit();
	public event OnPlayerHit PlayerHit;

	public static HawkBehavior hawk;
	public bool leftSpwn = false;
	public bool canFly = false;
	public float cooldown = 3;
	public float timer = 0;

	private float speed = 7;
	private int direction = 1;
	private bool down = false;
	public float sinMultiplier = -2;
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
			gameObject.transform.eulerAngles = new Vector3 (0, 180, 0);
		} else {
			direction = 1;
			gameObject.transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		if (timer < cooldown)
			timer += Time.deltaTime;
		else {
			canFly = true;
		}
		if (canFly) {
			//gameObject.transform.Translate ((speed * Time.deltaTime) * direction, 0, 0);
			gameObject.transform.Translate ((Vector3.right * (speed * Time.deltaTime) * direction), Space.Self);

			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, 5f * Mathf.Sin (sinMultiplier * speed), 0);

			if (sinMultiplier > .075f)
				down = true;
			else if (sinMultiplier < .025f)
				down = false;

			if (!down) {
				sinMultiplier += .001f;
			} else {
				sinMultiplier -= .001f;
			}
		}
	}



	void OnCollisionEnter(Collision collider)
	{
		if (collider.transform.tag == "Player") 
		{
			if(PlayerHit != null)
				PlayerHit();
		}
	}
}

