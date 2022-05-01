using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SnyderMode : MonoBehaviour
{
    [SerializeField] GameObject borderPanel;
    [SerializeField] Volume normalVolume;
    [SerializeField] Volume snyderVolume;

    bool inSnyderMode = false;

    public void Toggle() {
        if(inSnyderMode) {
            snyderVolume.enabled = false;
            normalVolume.enabled = true;
            borderPanel.SetActive(false);
        } else {
            snyderVolume.enabled = true;
            normalVolume.enabled = false;
            borderPanel.SetActive(true);
        }

        inSnyderMode = !inSnyderMode;
    }
}
