using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager I { get; private set; }

    [SerializeField] private Task[] tasks;
    private Task currentTask;
    private int index;
    
    private void Awake()
    {
        if (I != null)
        {
            Destroy(this);
            return;
        }
        if (tasks.Length <= 0)
        {
            Debug.LogError("TaskManager: tasks has no elements", this);
        }

        I = this;
        index = 0;
        currentTask = tasks[index];
    }

    private void SetupTask()
    {
        currentTask.onSetupTask.Invoke();
    }

    public void EndTask()
    {
        currentTask.onEndTask.Invoke();
        index++;

        if (index >= tasks.Length)
        {
            Debug.Log("Alls Tasks completed.");
            return;
        }
        
        currentTask = tasks[index];
        SetupTask();
    }
    
}