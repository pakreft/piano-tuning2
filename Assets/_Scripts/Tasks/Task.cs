using UnityEngine.Events;

[System.Serializable]
public struct Task
{
    public string instructionsMsg;
    public string hintMsg;
    
    public UnityEvent onSetupTask;
    public UnityEvent onEndTask;
}