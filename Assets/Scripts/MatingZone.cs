using UnityEngine;
using System.Collections;

public class MatingZone : MonoBehaviour
{
    public int Difficulty;

    private SpriteRenderer _heart1;
    private SpriteRenderer _heart2;
    private SpriteRenderer _heart3;
    private SpriteRenderer _heart4;
    private SpriteRenderer _heart5;

    private SpriteRenderer[] _sprites;

    // Use this for initialization
    void Start()
    {
        Difficulty = Random.Range(2, 6);
        _sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sprite in _sprites)
        {
            sprite.gameObject.SetActive(false);
            switch (sprite.gameObject.name)
            {
                case "heart1":
                    _heart1 = sprite;
                    break;
                case "heart2":
                    _heart2 = sprite;
                    break;
                case "heart3":
                    _heart3 = sprite;
                    break;
                case "heart4":
                    _heart4 = sprite;
                    break;
                case "heart5":
                    _heart5 = sprite;
                    break;
            }
        }

        _sprites = new SpriteRenderer[Difficulty];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
