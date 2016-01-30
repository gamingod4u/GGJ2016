using UnityEngine;
using System.Collections;

public class BackgroundObject : MonoBehaviour
{
    private BackgroundScrolling _scroller;

    // Use this for initialization
    void Start()
    {
        var world = GameObject.FindGameObjectWithTag("World");
        _scroller = world.GetComponent<BackgroundScrolling>();
    }

    // Update is called once per frame
    void Update()
    {
        var speed = _scroller.speed;
        var localPostion = transform.localPosition;
        transform.localPosition -= new Vector3(speed * Time.deltaTime, 0);
    }
}
