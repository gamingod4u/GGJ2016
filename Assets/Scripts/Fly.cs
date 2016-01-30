using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour
{
    private GameObject _sprite;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private bool _grounded;

    public LayerMask GroundMask;
    public Transform GroundCheck;
    public float MaxSpeed = 10.0f;

    // Use this for initialization
    void Start()
    {
        _sprite = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = _sprite.GetComponent<SpriteRenderer>();
        _animator = _sprite.GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        var colliders = Physics2D.OverlapCircleAll(GroundCheck.position, 0.1f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _grounded = true;
            }
        }

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _animator.SetFloat("Speed", Mathf.Abs(horizontal));

        _rigidBody.velocity = new Vector2(horizontal * MaxSpeed, vertical * MaxSpeed);

        if(horizontal < 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (horizontal > 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
