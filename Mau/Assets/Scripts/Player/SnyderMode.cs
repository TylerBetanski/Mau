using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SnyderMode : MonoBehaviour
{
    [SerializeField] public GameObject borderPanel;
    [SerializeField] public Volume normalVolume;
    [SerializeField] public  Volume snyderVolume;

    public bool inSnyderMode = false;

    public void Toggle() {
        if(inSnyderMode) {

        } else {

        }

        inSnyderMode = !inSnyderMode;
    }

    public void StartSnyderMode() {
        snyderVolume.enabled = true;
        normalVolume.enabled = false;
        borderPanel.SetActive(true);
    }

    public void StopSnyderMode() {
        snyderVolume.enabled = false;
        normalVolume.enabled = true;
        borderPanel.SetActive(false);
    }
}
