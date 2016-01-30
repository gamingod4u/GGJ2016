using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VitalityUpdater : MonoBehaviour
{
    private Text _text;
    private GameObject _playerGroup;
    private Mating _mating;

    // Use this for initialization
    void Start()
    {
        _text = GetComponent<Text>();
        _playerGroup = GameObject.FindGameObjectWithTag("Player");
        _mating = _playerGroup.GetComponent<Mating>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = string.Format("Vitality: {0,-5}", _mating.CurrentVitality);
    }
}
