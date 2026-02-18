using UnityEngine;
using TMPro;
public class UI_Manager : MonoBehaviour
{
//    public TMP_Text currentMaskReadout;
    int selectedMask=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCurrentMask(int currentMask)
    {
        selectedMask=currentMask;
//        currentMaskReadout.SetText("Current Mask: "+currentMask);
    }
    public int GetCurrentMask()
    {
        return selectedMask;
    }
}
