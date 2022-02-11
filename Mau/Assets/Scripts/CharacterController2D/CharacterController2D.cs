using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    private Vector2 Velocity { get { return rb2D.velocity; } }
    private Vector2 ColliderBottom { get{ return new Vector2((collider.bounds.min.x + collider.bounds.max.x) /2, collider.bounds.min.y); } }
    private bool _grounded = false;
    public bool Grounded { get { return _grounded; } private set { _grounded = value; } }
    public float Gravity { get { return Physics2D.gravity.y * rb2D.gravityScale; } }

    [SerializeField] private LayerMask collisionLayers;
    [SerializeField] private Vector2 maxVelocity = new Vector2(10, 20);
    [SerializeField] private float friction = 50.0f;

    private Rigidbody2D rb2D;
    private new Collider2D collider;

    private bool moving = false;

    public void AddVelocity(Vector2 dVelocity)
    {
        rb2D.velocity += dVelocity;
        moving = dVelocity != Vector2.zero;
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        CheckGrounded();

        ClampVelocity();
    }

    private void FixedUpdate()
    {
        if (!moving && Velocity.x != 0)
            ApplyFriction();

        moving = false;
    }

    private void ApplyFriction()
    {
        float dX = friction * Time.fixedDeltaTime * -Mathf.Sign(Velocity.x);
        if ((Velocity.x > 0 && Velocity.x + dX < 0)
            || (Velocity.x < 0 && Velocity.x + dX > 0))
            rb2D.velocity = new Vector2(0, Velocity.y);
        else
            rb2D.velocity = new Vector2(Velocity.x + dX, Velocity.y);
    }

    private void CheckGrounded()
    {
        Grounded = Physics2D.OverlapCircle(ColliderBottom, 0.5f, collisionLayers);
        
    }

    private void ClampVelocity()
    {
        rb2D.velocity = new Vector2(Mathf.Clamp(Velocity.x, -maxVelocity.x, maxVelocity.x), Mathf.Clamp(Velocity.y, -maxVelocity.y, maxVelocity.y));

        if (Mathf.Abs(Velocity.x) <= 0.5)
            rb2D.velocity = new Vector2(0, Velocity.y);
    }
}
