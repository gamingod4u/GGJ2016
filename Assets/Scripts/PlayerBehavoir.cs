using UnityEngine;
using System.Collections;

public class PlayerBehavoir : MonoBehaviour
{
    private float speed = .25f;
    private float direction = 1;
    private float gravity = 20;

    private float nextX = 0;
    private float nextY = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //gameObject.transform.localPosition += new Vector3((Input.GetAxis("Horizontal") * speed), Input.GetAxis("Vertical") * (speed));
        gameObject.transform.position += new Vector3(0, Input.GetAxis("Vertical") * (speed));
        gameObject.transform.position = new Vector3(0, gameObject.transform.position.y);

        if (Input.GetAxis("Horizontal") > .1f)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (Input.GetAxis("Horizontal") < -.1f)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }


        

        

	}
}
