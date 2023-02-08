using UnityEngine;

public class Loader : MonoBehaviour
{
    public static Loader I { get; private set; }

    
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
    }
    
    public void LoadDemoMode()
    {
        // UI
      //  menuUI.SetActive(false);
      //  gameUI.SetActive(true);
       // stepBackButton.SetActive(true);
      //  stepForwardButton.SetActive(true);
        
        //TaskManager.I.gameObject.SetActive(true);
    }
}