using UnityEngine;
using System.Collections;

public class TriggerDebug : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered from " + this.gameObject.name);
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Mating Zone Exited from " + this.gameObject.name);
    }
}
