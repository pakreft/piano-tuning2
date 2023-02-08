using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static Loader I { get; set; }
    
    
    private bool _trainingMode;
    
    private void Awake()
    {
        if (I != null)
        {
            Destroy(this);
            return;
        }
        
        I = this;
        Debug.Log("Loader initialized", this);
    }

    public void LoadTrainingMode()
    {
        UIManager.I.mainMenuUI.SetActive(false);
        UIManager.I.gameUI.SetActive(true);
        
        // Deactivate Buttons meant for Demo Mode
        UIManager.I.stepForwardBtn.gameObject.SetActive(false);
        UIManager.I.stepBackwardBtn.gameObject.SetActive(false);
        
        TaskManager.I.gameObject.SetActive(true);
        TaskManager.I.evOnDisable.AddListener(LoadTrainingModeEndcart);
    }
    
    public void LoadDemoMode()
    {
        _trainingMode = false;
        
        UIManager.I.mainMenuUI.SetActive(false);
        UIManager.I.gameUI.SetActive(true);
        
        TaskManager.I.gameObject.SetActive(true);
    }

    private void LoadTrainingModeEndcart()
    {
        _trainingMode = true;
        
        UIManager.I.endCart.SetActive(true);
        
        // Set hints and mistakes onto endcard TODO: use seperate fields for text and counter
        UIManager.I.endcartHintCounter.text = "HINTS USED:      " + TaskManager.I.hintCounter;
        UIManager.I.endcartMistakeCounter.text = "MISTAKES MADE:    " + TaskManager.I.mistakeCounter;

        // Disable buttons in In-Game UI
        UIManager.I.inGameMenuBtn.enabled = false;
        UIManager.I.showHintBtn.enabled = false;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_trainingMode == true)
        {
            LoadTrainingMode();
        }
        else
        {
            LoadDemoMode();
        }
    }
}