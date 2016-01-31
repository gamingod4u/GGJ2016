using UnityEngine;
using System.Collections;

public class Mating : MonoBehaviour
{
    private ButtonPrompt _promptBehavior;
    private int _startingVitality;
    private HawkSpwner _hawkSpwner;
    private int _vitalityAdjustment;
    private bool _invulnerable;

    public GameObject ButtonPrompt;
    public int CurrentVitality = 100;
    public float InvulnerableTime = 2;
    public MatingZone ActiveZone;

    // Use this for initialization
    void Start()
    {
        _invulnerable = false;
        _vitalityAdjustment = 0;
        _promptBehavior = ButtonPrompt.GetComponent<ButtonPrompt>();
        _startingVitality = CurrentVitality;
        _hawkSpwner = FindObjectOfType<HawkSpwner>();

        foreach(var enemy in _hawkSpwner.enemies)
        {
            enemy.GetComponent<HawkBehavior>().PlayerHit += OnPlayerHit;
        }
    }


    private void OnPlayerHit()
    {
        if (_invulnerable) { return; }
        _vitalityAdjustment -= 10;
        StartCoroutine(PlayerHit());
    }

    private IEnumerator PlayerHit()
    {
        _invulnerable = true;
        var invulnerableTill = Time.time + InvulnerableTime;
        while (invulnerableTill > Time.time)
        {
            yield return new WaitForSeconds(0.2f);
        }
		SoundManager.instance.PlaySingle (2);
        _invulnerable = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.1f);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.tag == "MatingZone")
            {
                ActiveZone = collider.gameObject.GetComponent<MatingZone>();
                if (!ButtonPrompt.activeSelf)
                {
                    ButtonPrompt.SetActive(true);
                }
                return;
            }
        }

        if (ButtonPrompt.activeSelf && !_promptBehavior.Animating)
        {
            ActiveZone = null;
            ButtonPrompt.SetActive(false);
        }
    }

    void Update()
    {
        CurrentVitality = _vitalityAdjustment + (_startingVitality - (int)Time.realtimeSinceStartup);
    }


    public void OnPromptSuccess()
    {
        if(ActiveZone != null)
        {
            ActiveZone.FlipHeart();
        }
    }
}
