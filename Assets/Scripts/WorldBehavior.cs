using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldBehavior : MonoBehaviour
{

    public GameObject background;
    public GameObject[] backgrounds;


    private GameObject player;
    private float speed = .25f;

    private float minX = -20;
    private float maxX = 0;
    // Use this for initialization
	void Start ()
    {
        backgrounds = new GameObject[2];
        

        for (int i = 0; i < 2; i++)
        {
            backgrounds[i] = Instantiate(background, new Vector2(-20 + (i * 18), 0), Quaternion.identity) as GameObject;

            if (i % 2 != 0 )
            {
                backgrounds[i].transform.localScale = new Vector3(backgrounds[i].transform.localScale.x * -1, backgrounds[i].transform.localScale.y);
                
            }
            backgrounds[i].transform.parent = this.gameObject.transform;

            if (i == 2)
            {
                maxX = backgrounds[i].transform.position.x;
            }
        }

        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].transform.position = new Vector3(backgrounds[i].transform.position.x + (Input.GetAxis("Horizontal") * -speed), 0, 0);


            if (Input.GetAxis("Horizontal") > .1f)
            {
                if (Vector3.Distance(backgrounds[i].transform.position, player.transform.position) > 18)
                {
                    backgrounds[i].transform.position = new Vector3(15.93f, 0);
                }
            }
            else if (Input.GetAxis("Horizontal") < -.1f)
            {
                if (Vector3.Distance(backgrounds[i].transform.position, player.transform.position) > 18)
                {
                    backgrounds[i].transform.position = new Vector3(-20.07f, 0);
                }
            }
        }

        





	}
}
