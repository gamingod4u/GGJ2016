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
    private Animator _animator;

    public float FlyAwayTime;
    public bool DestroyMe;
    public Sprite FullHeart;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        Difficulty = Random.Range(3, 6);
        _sprites = GetComponentsInChildren<SpriteRenderer>();
        var spritesTemp = new SpriteRenderer[Difficulty];
        foreach (var sprite in _sprites)
        {
            switch (sprite.gameObject.name)
            {
                case "heart1":
                    _heart1 = sprite;
                    spritesTemp[0] = _heart1;
                    break;
                case "heart2":
                    _heart2 = sprite;
                    spritesTemp[1] = _heart2;
                    break;
                case "heart3":
                    _heart3 = sprite;
                    spritesTemp[2] = _heart3;
                    break;
                case "heart4":
                    _heart4 = sprite;
                    if (Difficulty >= 4) spritesTemp[3] = _heart4;
                    else { _heart4.gameObject.SetActive(false); }
                    break;
                case "heart5":
                    _heart5 = sprite;
                    if (Difficulty >= 5) spritesTemp[4] = _heart5;
                    else { _heart5.gameObject.SetActive(false); }
                    break;
            }
        }
        _sprites = spritesTemp;

        foreach (var sprites in _sprites)
        {
            sprites.gameObject.SetActive(true);
        }
    }

    public void FlipHeart()
    {
        foreach (var _renderer in _sprites)
        {
            if (_renderer.sprite == FullHeart) continue;
            _renderer.sprite = FullHeart;
            return;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FlyAwayTime < Time.time)
        {
            FlyAwayTime = float.MaxValue;
            _animator.SetTrigger("FlyAway");
        }

        if (DestroyMe)
        {
            GameObject.Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
