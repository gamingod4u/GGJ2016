using System.Collections;
using UnityEngine;

public class ButtonPrompt : MonoBehaviour
{
    private GameObject X;
    private GameObject A;
    private GameObject B;
    private GameObject Y;

    private GameObject[] _buttons;

    // Use this for initialization
    void Start()
    {
        _buttons = new GameObject[4];

        foreach (var obj in this.transform)
        {
            var transform = obj as Transform;
            if (transform == null) continue;
            var gameObject = transform.gameObject;
            if (gameObject == null) continue;

            switch (gameObject.name)
            {
                case Buttons.X:
                    X = gameObject;
                    _buttons[0] = X;
                    break;
                case Buttons.A:
                    A = gameObject;
                    _buttons[1] = A;
                    break;
                case Buttons.B:
                    B = gameObject;
                    _buttons[2] = B;
                    break;
                case Buttons.Y:
                    Y = gameObject;
                    _buttons[3] = Y;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!AnyButtonsActive())
        {
            var activeButtonIndex = Random.Range(0, 3);
            _buttons[activeButtonIndex].SetActive(true);
        }

        if (Input.GetButtonDown(Buttons.X) && X.activeSelf)
        {
            X.SetActive(false);
        }

        if (Input.GetButtonDown(Buttons.A) && A.activeSelf)
        {
            A.SetActive(false);
        }

        if (Input.GetButtonDown(Buttons.B) && B.activeSelf)
        {
            B.SetActive(false);
        }

        if (Input.GetButtonDown(Buttons.Y) && Y.activeSelf)
        {
            Y.SetActive(false);
        }
    }

    private bool AnyButtonsActive()
    {
        foreach(var button in _buttons)
        {
            if (button.activeSelf) return true;
        }
        return false;
    }
}
