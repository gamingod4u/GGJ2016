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
            var localPostion = backgrounds[i].transform.localPosition;
			backgrounds[i].transform.localPosition -= new Vector3(speed * Time.deltaTime, 0);

			if (speed < -.1 && localPostion.x >22)
            {
				backgrounds[i].transform.localPosition = new Vector3(localPostion.x - 46, localPostion.y);
            }
			else if (speed > .1 && backgrounds[i].transform.localPosition.x < -18)
            {
				backgrounds[i].transform.localPosition = new Vector3(localPostion.x + 46, localPostion.y);
            }
        }
    }
}