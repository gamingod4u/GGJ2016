using System.Collections;
using UnityEngine;

public class ButtonPrompt : MonoBehaviour
{
    public class Msg
    {
        public const string OnPromptSuccess = "OnPromptSuccess";
        public const string OnPromptFailure = "OnPromptFailure";
    }

    private GameObject X;
    private GameObject A;
    private GameObject B;
    private GameObject Y;

    private GameObject[] _buttons;
    private Animator _animator;
    private double _startTime;

    public bool Animating = false;
    public double TimeLimit = 6d;

    // Use this for initialization
    void Start()
    {
        _buttons = new GameObject[4];
        _animator = this.GetComponent<Animator>();

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
        if (Animating)
        {
            return;
        }

        if (!AnyButtonsActive())
        {
            SetRandomButtonActive();
        }

        CheckButtonDown(Buttons.X, X);
        CheckButtonDown(Buttons.A, A);
        CheckButtonDown(Buttons.B, B);
        CheckButtonDown(Buttons.Y, Y);

        CheckTimer();
    }

    private void CheckButtonDown(string buttonName, GameObject button)
    {
        if (Input.GetButtonDown(buttonName) && button.activeSelf && !Animating)
        {
            Animating = true;
            StopAllCoroutines();
            StartCoroutine(OnSuccess());
        }
        else if (Input.GetButtonDown(buttonName) && !button.activeSelf && !Animating)
        {
            Animating = true;
            StopAllCoroutines();
            StartCoroutine(OnFailure());
        }
    }

    private IEnumerator OnSuccess()
    {
        _animator.SetTrigger("Success");
        _startTime = default(double);
        DarkenActiveButton(TimeLimit);
        yield return new WaitForSeconds(1);

        while (Animating)
        {
            yield return new WaitForSeconds(.2f);
        }

        SetRandomButtonActive();
        SendMessageUpwards(Msg.OnPromptSuccess, SendMessageOptions.DontRequireReceiver);
    }

    private IEnumerator OnFailure()
    {
        _animator.SetTrigger("Failure");
        _startTime = default(double);
        DarkenActiveButton(TimeLimit);
        yield return new WaitForSeconds(1);

        while (Animating)
        {
            yield return new WaitForSeconds(.2f);
        }

        SetRandomButtonActive();
        SendMessageUpwards(Msg.OnPromptFailure, SendMessageOptions.DontRequireReceiver);
    }

    private void CheckTimer()
    {
        if (_startTime == default(double))
        {
            _startTime = Time.fixedTime;
        }

        var deltaTime = Time.fixedTime - _startTime;

        if (deltaTime > TimeLimit)
        {
            StartCoroutine(OnFailure());
        }
        else
        {
            var endTime = TimeLimit - deltaTime;
            //DarkenActiveButton(endTime);
        }
    }

    private void DarkenActiveButton(double endTime)
    {
        var activeButton = GetActiveButton();
        float percentOfEnd = (float)(endTime / TimeLimit);
        var currentColor = activeButton.GetComponent<SpriteRenderer>().color;
        var newColor = new Color(currentColor.r, currentColor.g, currentColor.b, percentOfEnd);
        activeButton.GetComponent<SpriteRenderer>().color = newColor;
    }

    private GameObject GetActiveButton()
    {
        foreach (var button in _buttons)
        {
            if (button.activeSelf)
            {
                return button;
            }
        }

        throw new System.Exception("No active button to return");
    }

    private void SetRandomButtonActive()
    {
        foreach (var button in _buttons)
        {
            button.SetActive(false);
        }

        var activeButtonIndex = Random.Range(0, 4);
        _buttons[activeButtonIndex].SetActive(true);
    }

    private bool AnyButtonsActive()
    {
        foreach (var button in _buttons)
        {
            if (button.activeSelf) return true;
        }
        return false;
    }
}
