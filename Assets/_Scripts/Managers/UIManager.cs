using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager I { get; private set; }
    
    [Header("Textfields")]
    [SerializeField] private TextMeshProUGUI stepCounter;
    [SerializeField] private TextMeshProUGUI mistakeCounter;
    [SerializeField] private TextMeshProUGUI hintCounter;
    [SerializeField] private TextMeshProUGUI infoText;

    [Header("Buttons")]
    [SerializeField] private Button backButton;
    
    private void Awake()
    {
        if (I != null)
        {
            Destroy(this);
            return;
        }
        
        I = this;
    }
    
    // ----- Button Callbacks -----
    public void OnClickMenu()
    {
        //ToDo: 
    }
    
    public void OnClickShowHint()
    {
        if (TaskManager.I.hintUsed == false)
        {
            //TODO: Sound
            TaskManager.I.hintCounter++;
            SetHintCounter(TaskManager.I.hintCounter);
            TaskManager.I.hintUsed = true;
        }
        
        infoText.text = TaskManager.I.CurrentTask.hintMsg;
        backButton.gameObject.SetActive(true);
    }

    public void OnClickLeftArrow()
    {
        
    }

    public void OnClickRightArrow()
    {
        
    }

    public void OnClickBack()
    {
        //TODO: little sound
        infoText.text = TaskManager.I.CurrentTask.instructionsMsg;
        backButton.gameObject.SetActive(false);
    }
    
    // ----- Setter -----
    public void SetStepCounter(int c)
    {
        stepCounter.text = c + "/" + TaskManager.I.TasksLength;
    }

    public void SetMistakeCounter(int c)
    {
        mistakeCounter.text = c.ToString();
    }

    public void SetHintCounter(int c)
    {
        hintCounter.text = c.ToString();
    }

    public void SetInfoText(string text)
    {
        infoText.text = text;
    }

    public void SetBackButtonActive(bool x)
    {
        backButton.gameObject.SetActive(x);
    }
}