using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager I { get; private set; }
    
    
    [Header("UI Parent GameObjects")]
    [SerializeField] public GameObject mainMenuUI;
    [SerializeField] public GameObject gameUI;
    [SerializeField] public GameObject inGameMenuUI;
    [SerializeField] public GameObject endCart;
    
    [Header("Buttons")]
    [SerializeField] public Button showHintBtn;
    [SerializeField] public Button backToInstructionMsgBtn;
    [SerializeField] public Button stepForwardBtn;
    [SerializeField] public Button stepBackwardBtn;
    
    [Header("TMP's")]
    [SerializeField] public TextMeshProUGUI stepCounter;
    [SerializeField] public TextMeshProUGUI mistakeCounter;
    [SerializeField] public TextMeshProUGUI hintCounter;
    [SerializeField] public TextMeshProUGUI infoText;
    
    private void Awake()
    {
        if (I != null)
        {
            Destroy(this);
            return;
        }
        
        I = this;
        Debug.Log("UIManager initialized", this);
    }
    
    // ----- TMP Setter -----
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
}