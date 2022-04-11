using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationManager : MonoBehaviour
{
    private Vector3 rightPoint { get { return new Vector3(
        playerCollider.bounds.max.x - (playerCollider.bounds.max.x - playerCollider.bounds.min.x) * (1f/10f), 
        playerCollider.bounds.min.y + (playerCollider.bounds.max.y - playerCollider.bounds.min.y) * (1f/4f), 
        0); } }
    private Vector3 leftPoint { get { return new Vector3(
        playerCollider.bounds.max.x - (playerCollider.bounds.max.x - playerCollider.bounds.min.x) * (9f / 10f),
        playerCollider.bounds.min.y + (playerCollider.bounds.max.y - playerCollider.bounds.min.y) * (1f / 4f),
        0); } }
    private Vector3 centerPoint { get { return new Vector3(/*playerCollider.bounds.center.x*/ (transform.localScale.x > 0 ? playerCollider.bounds.max.x - 0.75f : playerCollider.bounds.min.x + 0.75f), playerCollider.bounds.min.y + .5f, 0); } }

    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private ContactFilter2D filter;
    [SerializeField] private Transform playerArt;
    [SerializeField] private float castDistance = 2;
    [SerializeField] private float smoothVelocity = 1.5f;
    [SerializeField] private float smoothTime = 0.2f;

    float prevScale = 0;

    private void Awake() {
        playerCollider = GetComponent<Collider2D>();
        filter.useLayerMask = true;
    }

    private void Update() {
        //    List<RaycastHit2D> rightHits = new List<RaycastHit2D>();
        //    List<RaycastHit2D> leftHits = new List<RaycastHit2D>();
        //    float rightAngle = 0;
        //    float leftAngle = 0;
        //    bool hitRight = false;
        //    bool hitLeft = false;


        //    if (Physics2D.Raycast(rightPoint, Vector2.down, filter, rightHits, 3) > 0) {
        //        float minDist = float.MaxValue;
        //        hitRight = true;
        //        foreach(RaycastHit2D hit in rightHits) {
        //            if (hit.distance < minDist) {
        //                minDist = hit.distance;
        //                rightAngle = Vector2.Angle(Vector2.up, hit.normal);
        //            }
        //        }
        //    }

        //    if (Physics2D.Raycast(leftPoint, Vector2.down, filter, leftHits, 3) > 0) {
        //        float minDist = float.MaxValue;
        //        hitLeft = true;
        //        foreach (RaycastHit2D hit in leftHits) {
        //            if (hit.distance < minDist) {
        //                minDist = hit.distance;
        //                leftAngle = Vector2.Angle(Vector2.up, hit.normal);
        //            }
        //        }
        //    }

        List<RaycastHit2D> hits = new List<RaycastHit2D>();
           float targetAngle = 0;
            if (Physics2D.Raycast(centerPoint, Vector2.down, filter, hits, castDistance) > 0) {
                float minDist = float.MaxValue;
                foreach (RaycastHit2D hit in hits) {
                    if (hit.distance<minDist) {
                        minDist = hit.distance;
                        targetAngle = Vector2.Angle(Vector2.up, hit.normal);
                        if (hit.normal.x > 0)
                            targetAngle *= -1;
                    }
                }
        }




        //    //if(hitRight && hitLeft) {
        //    //    targetAngle = (rightAngle + leftAngle) / 2f;
        //    //} else if(hitRight) {
        //    //    targetAngle = rightAngle;
        //    //} else if(hitLeft) {
        //    //    targetAngle = -leftAngle;
        //    //}

        //playerArt.rotation = Quaternion.Euler(0, 0, 45);

        //playerArt.rotation = Quaternion.Euler(0, 0, targetAngle);

        //if (Mathf.Sign(targetAngle) != Mathf.Sign(playerArt.rotation.eulerAngles.z)) {
        //    playerArt.rotation = Quaternion.Euler(0, 0, targetAngle);
        //} else {
        //    float smoothAngle = Mathf.SmoothDampAngle(playerArt.rotation.eulerAngles.z, targetAngle, ref smoothVelocity, smoothTime);
        //    playerArt.rotation = Quaternion.Euler(0, 0, smoothAngle);
        //}

        if(Mathf.Sign(transform.localScale.x) != Mathf.Sign(prevScale)) {
            playerArt.rotation = Quaternion.Euler(0, 0, targetAngle);
        } else {
            float smoothAngle = Mathf.SmoothDampAngle(playerArt.rotation.eulerAngles.z, targetAngle, ref smoothVelocity, smoothTime);
            playerArt.rotation = Quaternion.Euler(0, 0, smoothAngle);
        }

        prevScale = transform.localScale.x;
    }

    private void FixedUpdate() {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        float targetAngle = 0;
        if (Physics2D.Raycast(centerPoint, Vector2.down, filter, hits, castDistance) > 0) {
            float minDist = float.MaxValue;
            foreach (RaycastHit2D hit in hits) {
                if (hit.distance < minDist) {
                    minDist = hit.distance;
                    targetAngle = Vector2.Angle(Vector2.up, hit.normal);
                }
            }
        }




        //if(hitRight && hitLeft) {
        //    targetAngle = (rightAngle + leftAngle) / 2f;
        //} else if(hitRight) {
        //    targetAngle = rightAngle;
        //} else if(hitLeft) {
        //    targetAngle = -leftAngle;
        //}

        //playerArt.rotation = Quaternion.Euler(0, 0, 45);

        if (Mathf.Sign(targetAngle) != Mathf.Sign(playerArt.rotation.eulerAngles.z)) {
            playerArt.rotation = Quaternion.Euler(0, 0, targetAngle);
            //print("Target Angle: " + targetAngle + ", PlayerAngle: " + playerArt.rotation.eulerAngles.z);
        } else {
            float smoothAngle = Mathf.SmoothDampAngle(playerArt.rotation.eulerAngles.z, targetAngle, ref smoothVelocity, smoothTime);
            //print("Target Angle: " + targetAngle + ", Smooth Angle: " + smoothAngle + ", PlayerAngle: " + playerArt.rotation.eulerAngles.z);
            playerArt.rotation = Quaternion.Euler(0, 0, smoothAngle);
        }
    }

    private void OnDrawGizmosSelected() {
        playerCollider = GetComponent<Collider2D>();
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(centerPoint, .1f);
        Gizmos.DrawLine(centerPoint, centerPoint - new Vector3(0, castDistance, 0));
        //Gizmos.DrawSphere(rightPoint, .1f);
        //Gizmos.DrawSphere(leftPoint, .1f);
        //Gizmos.DrawLine(rightPoint, rightPoint - new Vector3(0, 3, 0));
        //Gizmos.DrawLine(leftPoint, leftPoint - new Vector3(0, 3, 0));
    }


}
