using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (transform.localScale.x < 5)
            transform.localScale += new Vector3(.025f, .025f, .025f);
    }
}
