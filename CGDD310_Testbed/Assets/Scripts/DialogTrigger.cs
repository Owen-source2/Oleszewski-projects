using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public string startNode;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Dialog Ready");
        if (other.gameObject.GetComponent<PlayerMove>()||other.gameObject.GetComponent<PlayerController>())
        {
            DialogManager.instance.LoadDialog(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print("Dialog Unready");
        DialogManager.instance.dialogReady = false;
    }

}

