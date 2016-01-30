using UnityEngine;

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
        for (int i = 0; i < backgrounds.Length; i++)
        {
			backgrounds[i].transform.localPosition -= new Vector3(speed * Time.deltaTime, 0);

			if (speed < -.1 && backgrounds[i].transform.localPosition.x >22)
            {
				backgrounds[i].transform.localPosition = new Vector3(backgrounds[i].transform.localPosition.x - 40, 0);
            }
			else if (speed > .1 && backgrounds[i].transform.localPosition.x < -18)
            {
				backgrounds[i].transform.localPosition = new Vector3(backgrounds[i].transform.localPosition.x + 40, 0);
            }
        }
    }
}