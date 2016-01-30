using UnityEngine;
using System.Collections;

public class Mating : MonoBehaviour
{
    private ButtonPrompt _promptBehavior;
    private int _startingVitality;

    public GameObject ButtonPrompt;
    public int CurrentVitality = 100;

    // Use this for initialization
    void Start()
    {
        _promptBehavior = ButtonPrompt.GetComponent<ButtonPrompt>();
        _startingVitality = CurrentVitality;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.1f);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.tag == "MatingZone")
            {
                if (!ButtonPrompt.activeSelf)
                {
                    ButtonPrompt.SetActive(true);
                }
                return;
            }
        }

        if (ButtonPrompt.activeSelf && !_promptBehavior.Animating)
        {
            ButtonPrompt.SetActive(false);
        }
    }

    void Update()
    {
        CurrentVitality = _startingVitality - (int)Time.realtimeSinceStartup;
    }
}
