using UnityEngine;

public class AddPianoKeySounds : MonoBehaviour
{
    public AudioClip[] sounds;
    
    private void Awake()
    {
        int i = 0;
        
        foreach (Transform child in transform)
        {
            AudioSource audioSource = child.gameObject.AddComponent<AudioSource>();
            audioSource.clip = sounds[i];

            i++;
        }
        
        Destroy(this);
    }
}