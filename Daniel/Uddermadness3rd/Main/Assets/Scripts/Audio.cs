using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public Button audioButt;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Button Sound = gameObject.GetComponent<Button>();
        Sound.onClick.AddListener(Pause);
    }

   void Pause() {
        Debug.Log("mute toggle");

        audioSource = audioButt.GetComponent<AudioSource>();
        if(!audioSource.isPlaying) {
            audioSource.Play();
            //audioButt.spriteState.pressedSprit;
        } else {
            audioSource.Pause();
        }
    }
}
