using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public static TaskManager I { get; private set; }

    
    [SerializeField] private Task[] tasks;
    
    public int TasksLength { get; private set; }
    public Task CurrentTask { get; private set; }

    [HideInInspector] public UnityEvent evOnDisable;
    [HideInInspector] public int hintCounter;
    [HideInInspector] public int mistakeCounter;
    [HideInInspector] public bool hintUsed;
    
    private int _index;
    
    // ----- Unity Functions -----
    private void Awake()
    {
        if (I != null)
        {
            Destroy(this);
            return;
        }
        
        I = this;
        Debug.Log("TaskManager initialized and set to inactive now", this);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Debug.Log("dwadawdada");
        _index = 0;
        TasksLength = tasks.Length;
        
        if (TasksLength <= 0)
        {
            Debug.LogError("TaskManager: tasks[] has no elements", this);
            return;
        }
        
        CurrentTask = tasks[_index];
        hintCounter = 0;
        mistakeCounter = 0;
        
        UIManager.I.SetHintCounter(hintCounter);
        UIManager.I.SetMistakeCounter(mistakeCounter);
        
        SetupCurrentTask();
    }

    private void OnDisable()
    {
        evOnDisable.Invoke();
        //ToDo: Show end cart (with different text while in demo mode)
    }

    // ----- Functions -----
    public void TaskCompleted()
    {
        EndCurrentTask();
        
        // Check if that was last task
        if (_index + 1 >= tasks.Length)
        {
            enabled = false;
            return;
        }
        
        // Set next task as new current task
        _index++;
        CurrentTask = tasks[_index];
        
        SetupCurrentTask();
    }
    
    private void SetupCurrentTask()
    {
        CurrentTask.onSetupTask.Invoke();
        hintUsed = false;
        
        UIManager.I.SetInfoText(CurrentTask.instructionsMsg);
        UIManager.I.SetStepCounter(_index + 1);
    }

    private void EndCurrentTask()
    {
        CurrentTask.onEndTask.Invoke();
        UIManager.I.backToInstructionMsgBtn.gameObject.SetActive(false);
    }
}