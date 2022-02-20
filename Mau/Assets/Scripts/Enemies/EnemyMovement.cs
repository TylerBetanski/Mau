using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Collider2D groundCollider;
    [SerializeField] Transform circleTransform;
    [SerializeField] private int moveSpeed;
    Rigidbody2D rb;
    private bool isGround;
    private bool isWall;
    private Vector2 ColliderBottom { get { return new Vector2(groundCollider.bounds.center.x, groundCollider.bounds.min.y); } }
    private Vector2 ColliderSide { get { return new Vector2(groundCollider.bounds.center.x, groundCollider.bounds.center.y); } }
    [SerializeField] private LayerMask collisionLayers;
    private void CheckForObstacle()
    {
        Collider2D collidedGround = Physics2D.OverlapCircle(ColliderBottom, 0.5f, collisionLayers);
        if (collidedGround != null && collidedGround.tag == "Ground")
        {
            isGround = true;
        }
        else 
        {
            isGround = false;
        }

        Collider2D collidedWall = Physics2D.OverlapCircle(ColliderSide, 0.5f, collisionLayers);
        if (collidedWall != null && collidedWall.tag == "Ground")
        {
            isWall = true;
        }
        else
        {
            isWall = false;
        }
    }

    private void Awake()
    {
        rb  = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void FixedUpdate()
    {
        CheckForObstacle();
        if (!isGround || isWall)
        {
            rb.velocity = new Vector2(0, 0);
            Flip();
        }
        else 
        {
            Move(moveSpeed);
        }
    }

    private void Move(int moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed, 0);
    }

    private void Flip()
    {
        moveSpeed = 0 - moveSpeed;
        circleTransform.localPosition = new Vector3(circleTransform.localPosition.x * -1, circleTransform.localPosition.y, circleTransform.localPosition.z);
        CheckForObstacle();
    }
}
