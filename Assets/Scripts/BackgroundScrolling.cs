using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BackgroundScrolling : MonoBehaviour
{
    public GameObject background;

    public GameObject[] backgrounds;

    public float speed;
    void Start()
    {

    }



    void Update()
    {
        speed = Input.GetAxis("Horizontal") * 5;
        for (int i = 0; i < 2; i++)
        {
            backgrounds[i].transform.position += new Vector3(speed * Time.deltaTime, 0);


            if (speed > .1 && backgrounds[i].transform.position.x > 20)
            {
                backgrounds[i].transform.position = new Vector3(backgrounds[i].transform.position.x - 40, 0);
            }
            else if (speed < -.1 && backgrounds[i].transform.position.x < -20)
            {
                backgrounds[i].transform.position = new Vector3(backgrounds[i].transform.position.x + 40, 0);
            }
        }
    }
}