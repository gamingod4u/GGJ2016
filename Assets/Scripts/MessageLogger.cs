using UnityEngine;
using System.Collections;

public class MessageLogger : MonoBehaviour
{
    public void OnPromptSuccess()
    {
        Debug.Log("OnPromptSuccess");
    }

    public void OnPromptFailure()
    {
        Debug.Log("OnPromptFailure");
    }
}
