using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    //setting game object and audio source for the audio
    public GameObject audioObject;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Button Sound = gameObject.GetComponent<Button>();
        //Sound.onClick.AddListener(Music);
    }

   public void Music() {
        Debug.Log("mute toggle");

        audioSource = audioObject.GetComponent<AudioSource>();
        //if audio is not clicked then play
        if(!audioSource.isPlaying) {
            audioSource.Play();
        } 

        //else if audio is clicked, then pause
        else if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
}
