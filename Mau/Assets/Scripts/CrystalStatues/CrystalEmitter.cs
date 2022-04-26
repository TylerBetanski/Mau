using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CrystalEmitter : MonoBehaviour
{
    private Vector3 RayDirection { get { return new Vector3(Mathf.Cos((angle + 180) * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * 100; } }

    [SerializeField] private bool active;
    [SerializeField, Range(0, 360)] private float angle;
    [SerializeField, Range(0, 90)] private int increment = 45;
    [SerializeField] private float rotationTime = 0.1f;
    [SerializeField] private ContactFilter2D filter;

    private CrystalEmitter parentEmitter;

    private Transform VFX;

    private LineRenderer lineRenderer;

    private CrystalReciever currentReciever;
    private bool disabling = false;

    private void Awake() {
        filter.useLayerMask = true;
        lineRenderer = GetComponent<LineRenderer>();
        VFX = transform.parent.Find("HitFX");

        if (active)
            Activate();
        else
            Deactivate();
    }


    private void Update() {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        lineRenderer.SetPosition(1, transform.position);
        if ((active || disabling) && Physics2D.Raycast(transform.position, RayDirection, filter, hits, 1000) > 0) {
            foreach(RaycastHit2D hit in hits) {
                if (hit.transform == transform.parent
                    || hit.transform == transform.parent.parent)
                    continue;

                if(hit.transform.GetComponentInChildren<CrystalReciever>() == null) {
                    if(currentReciever != null) {
                        currentReciever.Disable();
                        currentReciever = null;
                    }
                    lineRenderer.SetPosition(0, hit.point);
                    VFX.position = hit.point;
                    break;
                } else {
                    if (hit.transform.GetComponentInChildren<CrystalEmitter>() == parentEmitter)
                        continue;

                    if(currentReciever != null && currentReciever != hit.transform.GetComponentInChildren<CrystalReciever>()) {
                        currentReciever.Disable();
                        currentReciever.GetComponentInChildren<CrystalEmitter>().setParentEmitter(null);
                        currentReciever = hit.transform.GetComponentInChildren<CrystalReciever>();
                        currentReciever.Enable();
                        currentReciever.GetComponentInChildren<CrystalEmitter>().setParentEmitter(this);
                    } else {
                        currentReciever = hit.transform.GetComponentInChildren<CrystalReciever>();
                        if (!disabling) {
                            currentReciever.Enable();
                            currentReciever.GetComponentInChildren<CrystalEmitter>().setParentEmitter(this);
                        } else {
                            currentReciever.Disable();
                            currentReciever.GetComponentInChildren<CrystalEmitter>().setParentEmitter(null);
                        }
                    }
                    lineRenderer.SetPosition(0, hit.point);
                    VFX.position = hit.point;
                    disabling = false;
                    break;
                }
            }
        }

        if(!active) {
            VFX.GetComponent<ParticleSystem>().Stop();
            GetComponent<ParticleSystem>().Stop();
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
        lineRenderer.enabled = true;
        VFX.GetComponent<ParticleSystem>().Play();
        transform.GetComponent<ParticleSystem>().Play();
        transform.GetComponent<Light2D>().enabled = true;
    }

    public void Deactivate() {
        active = false;
        lineRenderer.enabled = false;

        VFX.GetComponent<ParticleSystem>().Clear();

        transform.GetComponent<ParticleSystem>().Stop();
        transform.GetComponent<ParticleSystem>().Clear();
        transform.GetComponent<Light2D>().enabled = false;

        disabling = true;
    }

    public void setParentEmitter(CrystalEmitter em) {
        parentEmitter = em;
    }

    public bool isActive() { return active; }
    public void setActive(bool ac) { active = ac; }

    public float getAngle() { return angle; }
    public void setAngle(float ang) { angle = ang; }
}
