using UnityEngine;
using TMPro;

public class MaskSelect : MonoBehaviour
{
    public int maskSelected=0;
    public UI_Manager uiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiManager.UpdateCurrentMask(maskSelected);
    }
    public void SwitchMask(int switchMaskTo)
    {
        maskSelected=switchMaskTo;
    }
}
