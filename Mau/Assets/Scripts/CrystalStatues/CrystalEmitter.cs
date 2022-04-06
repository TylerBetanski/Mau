using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalEmitter : MonoBehaviour
{
    private Vector3 RayDirection { get { return new Vector3(Mathf.Cos((angle + 180) * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * 100; } }

    [SerializeField] private bool active;
    [SerializeField, Range(0, 360)] private float angle;
    [SerializeField, Range(0, 90)] private int increment = 45;
    [SerializeField] private float rotationTime = 0.1f;
    [SerializeField] private ContactFilter2D filter;

    private CrystalReciever currentReciever;

    private void Awake() {
        filter.useLayerMask = true;
    }


    private void Update() {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        if (active && Physics2D.Raycast(transform.position, RayDirection, filter, hits, 1000) > 0) {
            foreach(RaycastHit2D hit in hits) {
                if (hit.transform == transform.parent)
                    continue;

                if(hit.transform.GetComponent<CrystalReciever>() == null) {
                    if(currentReciever != null) {
                        currentReciever.Disable();
                        currentReciever = null;
                    }
                    break;
                } else {
                    if(currentReciever != null && currentReciever != hit.transform.GetComponent<CrystalReciever>()) {
                        currentReciever.Disable();
                        currentReciever = hit.transform.GetComponent<CrystalReciever>();
                        currentReciever.Enable();
                    } else {
                        currentReciever = hit.transform.GetComponent<CrystalReciever>();
                        currentReciever.Enable();
                    }
                    break;
                }
            }
        }

    }

    private void OnValidate() {
        angle = ((int)(angle / increment)) * increment;
    }

    public void Rotate() {
        if (active) {
            float targetAngle = angle + increment;
            StartCoroutine(RotateBeam(targetAngle));
        }
    }

    private IEnumerator RotateBeam(float newAngle) {
        float time = 0;

        while (time < rotationTime) {
            angle = Mathf.Lerp(angle, newAngle, (time / rotationTime));
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime;
        }

        angle = newAngle;
    }

    private void OnDrawGizmosSelected() {
        if (active)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, RayDirection);
    }

    public void Activate() {
        active = true;
    }

    public void Deactivate() {
        active = false;
    }
}
