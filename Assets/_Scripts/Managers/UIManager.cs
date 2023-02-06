using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager I { get; private set; }
    
    [SerializeField] private TextMeshProUGUI stepCounter;
    [SerializeField] private TextMeshProUGUI mistakeCounter;
    [SerializeField] private TextMeshProUGUI hintCounter;
    [SerializeField] private TextMeshProUGUI infoText;

    public void OnClickShowHintButton()
    {
        
    }

    public void OnClickMenuButton()
    {
        
    }

    // ----- Setter -----
    public void SetStepCounter(int c)
    {
        stepCounter.text = c + "x";
    }

    public void SetMistakeCounter(int c)
    {
        mistakeCounter.text = c + "x";
    }

    public void SetHintCounter(int c)
    {
        hintCounter.text = c + "x";
    }

    public void SetInfoText(string text)
    {
        infoText.text = text;
    }
}