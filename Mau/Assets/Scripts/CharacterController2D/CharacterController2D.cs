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

    private Rigidbody2D rb2D;
    private new Collider2D collider;

    public void AddVelocity(Vector2 dVelocity)
    {
        rb2D.velocity += dVelocity;
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    
    private void FixedUpdate()
    {
        CheckGrounded();

        ClampVelocity();
    }

    private void CheckGrounded()
    {
        Grounded = Physics2D.OverlapCircle(ColliderBottom, 0.25f, collisionLayers);
    }

    private void ClampVelocity()
    {
        rb2D.velocity = new Vector2(Mathf.Clamp(Velocity.x, -maxVelocity.x, maxVelocity.x), Mathf.Clamp(Velocity.y, -maxVelocity.y, maxVelocity.y)); 
    }
}
