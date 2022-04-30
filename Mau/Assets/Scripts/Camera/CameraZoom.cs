using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] float initialSize;
    [SerializeField] float zoomedOutSize;
    
    private Camera mainCamera;
    bool zoomed;
    bool isZooming;

    [SerializeField] float zoomingTime;
    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        initialSize = mainCamera.orthographicSize;
        zoomed = false;
        isZooming = false;
    }
    public void changeZoom()
    {
        if (!isZooming) {   
            if (zoomed)
            {
                StartCoroutine(ZoomIn());
                zoomed = false;
            }
            else
            {
                StartCoroutine(ZoomOut());
                zoomed = true;
            }
        }
    }
    public IEnumerator ZoomIn() {
        isZooming = true;
        float changeAmount = 0.5f;

        while (mainCamera.orthographicSize > initialSize) 
        {
            yield return new WaitForSeconds(zoomingTime);
            mainCamera.orthographicSize -= changeAmount;
        }
        isZooming = false;
    }
    IEnumerator ZoomOut()
    {   
        isZooming = true;
        float changeAmount = 0.5f;

        while (mainCamera.orthographicSize < zoomedOutSize)
        {
            yield return new WaitForSeconds(zoomingTime);
            mainCamera.orthographicSize += changeAmount;
        }
        isZooming = false;
    }

    public IEnumerator ZoomTo(float size, float time) {
        isZooming = true;
        float oldSize = mainCamera.orthographicSize;
        float t = 0;
        while(t < time) {
            yield return new WaitForSeconds(Time.deltaTime);
            t += Time.deltaTime;
            mainCamera.orthographicSize = Mathf.Lerp(oldSize, size, t / time);
        }
        mainCamera.orthographicSize = size;
    }
}
