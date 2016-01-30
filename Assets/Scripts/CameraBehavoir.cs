using UnityEngine;
using System.Collections;

public class CameraBehavoir : MonoBehaviour
{

    private GameObject player;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(player.transform.localPosition.x, gameObject.transform.position.y, -10);
	}
}
