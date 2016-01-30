using UnityEngine;
using System.Collections;

public class HawkSpwner : MonoBehaviour 
{

	public GameObject hawkPrefab;

	public GameObject[] enemies;

	public GameObject leftSpwn;
	public GameObject rightSpwn;


	private GameObject player;
	// Use this for initialization
	void Start () 
	{	
		player = GameObject.FindGameObjectWithTag ("Player");

		Random.seed = (int)Time.time *20;
		enemies = new GameObject[3];

		for (int i = 0; i < 3; i++) 
		{	
			int spwnPos = (int) (Random.Range (0, 100) *.25f);

			if (spwnPos %2 == 0) {
				enemies [i] = Instantiate (hawkPrefab, new Vector3 (leftSpwn.transform.position.x, Random.Range (-400.0f, 500.0f)/100), Quaternion.identity) as GameObject;
				HawkBehavior hawk = enemies [i].GetComponent<HawkBehavior> ();
				hawk.cooldown = (Random.Range (0, 100) /10);
				hawk.leftSpwn = true;

			} else {
				enemies [i] = Instantiate (hawkPrefab, new Vector3 (rightSpwn.transform.position.x, Random.Range (-400.0f, 500.0f)/100), Quaternion.identity) as GameObject;
				HawkBehavior hawk = enemies [i].GetComponent<HawkBehavior> ();
				hawk.cooldown = (Random.Range (0, 100) /10);
				hawk.leftSpwn = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
			
		for (int i = 0; i < enemies.Length; i++) 
		{
			if (Vector3.Distance (enemies [i].transform.position, player.transform.position) > 11) 
			{
				Debug.Log (Vector3.Distance (enemies [i].transform.position, player.transform.position));


				HawkBehavior hawk = enemies [i].GetComponent<HawkBehavior> ();
				hawk.canFly = false;
				hawk.cooldown = (Random.Range (0, 100) /10);
				hawk.timer = 0;
				hawk.sinMultiplier = 0;
				int spwnPos = (int) (Random.Range (0, 100) *.25f);
				Debug.Log (spwnPos);


				if (spwnPos %2 == 0) {
					enemies [i].transform.position = new Vector3 (leftSpwn.transform.position.x, Random.Range (-400.0f, 500.0f) / 100);
					hawk.leftSpwn = true;

				} else {
					enemies [i].transform.position = new Vector3 (rightSpwn.transform.position.x, Random.Range (-400.0f, 500.0f)/100);
					hawk.leftSpwn = false;
				}
			}
		}


	}
}
