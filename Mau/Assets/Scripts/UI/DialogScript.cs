using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    [SerializeField] Sprite[] dialog;
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject player;
    [SerializeField] float waitTime;

    private int state;
    private bool complete;
    private bool waiting;

    private void Awake()
    {
        complete = false;
        state = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!complete && (collision.gameObject.tag == "Player"))
        {
            dialogBox.GetComponent<Image>().color = new Color(dialogBox.GetComponent<Image>().color.r, dialogBox.GetComponent<Image>().color.g, dialogBox.GetComponent<Image>().color.b, 1);
            player.GetComponent<PlayerController>().setDialog(dialogBox);
            player.GetComponent<PlayerController>().dialog = true;
            if (state == 0)
                updateDialog();
        }
        
    }

    public void updateDialog() {
        if (!complete)
        {
            if (!waiting)
            {
                StartCoroutine(dialogWait());
                dialogBox.GetComponent<Image>().sprite = dialog[state];
                if (state < dialog.Length - 1)
                    state++;
                else {
                    complete = true;
                }
                    
            }
        }
        else
        {
            player.GetComponent<PlayerController>().dialog = false;
            Destroy(dialogBox);
        }
    }

    public IEnumerator dialogWait() {
        waiting = true;
        yield return new WaitForSeconds(waitTime);
        waiting = false;
    }

}

/*public void setDialog(GameObject dialog)
{
    currentDialog = dialog;
}
public void advanceDialog()
{
    if (currentDialog != null)
        currentDialog.GetComponentInChildren<DialogScript>().updateDialog();
}*/
