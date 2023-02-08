public class ClickableCorrect : ClickableBase
{
    private void Awake()
    {
        if (sound == null)
        {
            //TODO - set sound of correct clicked
        }
    }

    private void OnMouseDown()
    {
        //TODO play sound
        onClick?.Invoke();
        //TaskManager.I.TaskCompleted();
    }
}