using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using Yarn.Unity;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public GameManager gman;
    public DialogueRunner dialogueRunner;
    public static UnityAction DialogStart, DialogOver;

    public bool dialogReady, dialogStarted, tornadoMoving=false;
    public bool hasDiamond = false;

    void Awake()
    {
        if (instance == null)
            instance = this;

    }

    public void LoadDialog(DialogTrigger dTrigger)
    {

        //Set the start node for the dialog runner
        dialogueRunner.startNode = dTrigger.startNode;
        //Put the portrait in the dialog box

        //the dialog is ready to view
        dialogReady = true;
    }

    public void StartDialog()
    {
        if (dialogReady && !dialogStarted)
        {

            // just to be careful make sure the runner is stopped
            dialogueRunner.Stop();

            dialogueRunner.StartDialogue(dialogueRunner.startNode);
            if (DialogStart != null)
                DialogStart();

            dialogStarted = true;
            print(dialogStarted);
        }
    }
    public void OnDialogOver()
    {
        if (DialogStart != null)
            DialogOver();

        dialogStarted = false;

    }

    public void GotDiamond()
    {
        //Set the Diamond variable in Yarnspinner
        hasDiamond = true;
        dialogueRunner.VariableStorage.SetValue("$hasDiamond", true);
    }
    public void StartTornado()
    {
        tornadoMoving=true;
        dialogueRunner.VariableStorage.SetValue("$tornadoComing",true);
        gman.StartTornado();
    }
}
