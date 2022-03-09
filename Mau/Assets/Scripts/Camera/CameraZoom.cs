using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] float initialSize;
    [SerializeField] float zoomedOutSize;
    
    private Camera mainCamera;
    bool zoom;
    
    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        initialSize = mainCamera.orthographicSize;
        zoom = false;
    }
    public void changeZoom() {
        if (zoom)
        {
            mainCamera.orthographicSize = initialSize;
            zoom = false;
        }
        else {
            mainCamera.orthographicSize = zoomedOutSize;
            zoom = true;
        }
    }
}
