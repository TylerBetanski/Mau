using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBGListener : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision) {
        GameObject collGO = collision.gameObject;
        if (collGO.tag == "Player") {
            GameObject clone = Instantiate(transform.parent.gameObject);

            float xDist = collGO.transform.position.x - transform.position.x;
            float yDist = collGO.transform.position.y - transform.position.y;

            print("XDist: " + Mathf.Abs(xDist) + ", YDist: " + Mathf.Abs(yDist));

            if (Mathf.Abs(xDist) > 5)
                clone.transform.position += new Vector3(80 * Mathf.Sign(xDist), 0, 0);
            if (Mathf.Abs(yDist) > 5)
                clone.transform.position += new Vector3(52 * Mathf.Sign(yDist), 0, 0);
        }
    }
}
