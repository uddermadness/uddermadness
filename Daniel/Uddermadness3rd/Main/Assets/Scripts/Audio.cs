﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public GameObject audioObject;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Button Sound = gameObject.GetComponent<Button>();
        Sound.onClick.AddListener(Pause);
    }

   void Pause() {
        Debug.Log("mute toggle");

        audioSource = audioObject.GetComponent<AudioSource>();
        if(!audioSource.isPlaying) {
            audioSource.Play();
        } else {
            audioSource.Pause();
        }
    }
}
