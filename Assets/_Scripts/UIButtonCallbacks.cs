using UnityEngine;

public class UIButtonCallbacks : MonoBehaviour
{
    public static UIButtonCallbacks I { get; private set; }

    
    private void Awake()
    {
        if (I != null)
        {
            Destroy(this);
            return;
        }
        
        I = this;
        Debug.Log("UIButtonCallbacks initialized", this);
    }
    
    // ----- Main Menu Buttons -----
    public void OnTrainingModeBtn()
    {
        Loader.I.LoadTrainingMode();
    }

    public void OnDemoModeBtn()
    {
        Loader.I.LoadDemoMode();
    }
    
    public void OnExitBtn()
    {
        Application.Quit();
    }
    
    // ----- In-Game Buttons -----
    public void OnInGameMenuBtn()
    {
        bool s = !UIManager.I.inGameMenuUI.activeSelf;
        UIManager.I.inGameMenuUI.SetActive(s);
    }
    
    public void OnShowHintBtn()
    { 
        if (TaskManager.I.hintUsed == false)
        {
            //TODO: Sound
            TaskManager.I.hintCounter++;
            UIManager.I.SetHintCounter(TaskManager.I.hintCounter);
            TaskManager.I.hintUsed = true;
        }
        
        UIManager.I.SetInfoText(TaskManager.I.CurrentTask.hintMsg);
        UIManager.I.backToInstructionMsgBtn.gameObject.SetActive(true);
    }
    
    public void OnBackToInstructionMsgBtn()
    {
        //TODO: little sound
        UIManager.I.SetInfoText(TaskManager.I.CurrentTask.instructionsMsg);
        UIManager.I.backToInstructionMsgBtn.gameObject.SetActive(false);
    }
    
    public void OnRestartBtn()
    {
        
    }

    public void OnBackToMainMenuBtn()
    {
        
    }
    
    // ----- Demo Mode Specific Buttons -----
    public void OnStepForwardBtn()
    {
        
    }

    public void OnStepBackwardsBtn()
    {
        
    }
}