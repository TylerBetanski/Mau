using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalTransmitter : MonoBehaviour
{
    [SerializeField] private List<GameObject> signalRecievers;

    public void TransmitSignal()
    {
        for (int i = 0; i < signalRecievers.Count; i++)
        {
            ISignalReciever reciever = signalRecievers[i].GetComponent<ISignalReciever>();
            if (reciever != null)
                reciever.RecieveSignal();
        }
    }
}
