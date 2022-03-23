using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarcophagus : InteractableObject
{
    [SerializeField] private float openTime;
    [SerializeField] private float transitionTime;
    [SerializeField] private Transform lid;
    [SerializeField] private Transform activateObject;
    private bool isOpen;
    private bool isMoving;

    private WaitForSeconds deltaWait;
    private WaitForSeconds openWait;

    private Vector3 lidStart;
    private Vector3 lidEnd;

    private void Awake()
    {
        deltaWait = new WaitForSeconds(Time.fixedDeltaTime);
        openWait = new WaitForSeconds(openTime);

        if(lid == null)
        {
            lid = transform.Find("Lid");
        }
        if(activateObject == null)
        {
            activateObject = transform.Find("ActivateObject");
        }

        lidStart = lid.position;
        lidEnd = new Vector3(lid.position.x, lid.position.y, lid.position.z) + new Vector3(lid.localScale.x, 0, 0);
    }


    public override void Interact(GameObject interactingObject)
    {
        if(interactingObject.tag == "Player")
        {
            if(!isOpen)
            {
                isOpen = true;
                StartCoroutine(OpenSarcophagus());
            }
        }
    }

    private IEnumerator OpenSarcophagus()
    {
        float time = 0;

        while(time < transitionTime)
        {
            yield return deltaWait;
            time += Time.fixedDeltaTime;

            lid.position = Vector3.Lerp(lidStart, lidEnd, time / transitionTime);
        }

        lid.position = lidEnd;

        activateObject.GetComponent<ISignalReciever>().RecieveSignal();

        StartCoroutine(WaitOpen());
    }

    private IEnumerator WaitOpen()
    {
        yield return openWait;
        StartCoroutine(CloseSarcophagus());
    }

    private IEnumerator CloseSarcophagus()
    {
        float time = 0;

        while (time < transitionTime)
        {
            yield return deltaWait;
            time += Time.fixedDeltaTime;

            lid.position = Vector3.Lerp(lidEnd, lidStart, time / transitionTime);
        }

        lid.position = lidStart;

        activateObject.GetComponent<ISignalReciever>().RecieveSignal();

        isOpen = false;
    }
}
