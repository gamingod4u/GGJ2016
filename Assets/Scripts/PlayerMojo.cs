using UnityEngine;
using System.Collections;

public class PlayerMojo : MonoBehaviour
{
    public int Mojo = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnPromptSuccess()
    {
        Mojo++;
    }

    public void OnPromptFailure()
    {
        Mojo--;
    } 
}
