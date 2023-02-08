using UnityEngine;
using System.Collections;

public class ClickableMistake : ClickableBase
{
    [SerializeField] private float deactivateTimeInS = 3f;
    private bool _clicked = false;

    private void Awake()
    {
        if (sound == null)
        {
            //TODO - set sound of correct clicked
        }
    }

    private void OnMouseDown()
    {
        if (_clicked == false)
        {
            //TaskManager.I.mistakeCounter++;
        }
        
        //TODO play sound
        onClick?.Invoke();
        StartCoroutine(DeactivateComponent());
    }

    private IEnumerator DeactivateComponent()
    {
        enabled = false;
        yield return new WaitForSeconds(deactivateTimeInS);
        enabled = true;
    }
}