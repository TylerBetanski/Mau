using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformListener : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SignalTransmitter>().TransmitSignal();
    }
}
