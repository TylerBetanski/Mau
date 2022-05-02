using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothFactor = 0.1f;
    [SerializeField] private float distanceThreshold = 0.05f;

    private void FixedUpdate()
    {
        if(target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothFactor);

            float dist = Vector3.Distance(transform.position, targetPosition);
            if (dist <= distanceThreshold)
                transform.position = targetPosition;
        }
    }

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetTarget(GameObject newTarget) {
        target = newTarget.transform;
    }
}
