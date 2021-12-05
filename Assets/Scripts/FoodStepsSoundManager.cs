using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStepsSoundManager : MonoBehaviour { 

    public AudioSource AudioSource;

public AudioClip FootStepClip;


    public void PlayFootStepSE()
    {
        if (!AudioSource.isPlaying)
        {
            Debug.Log(111);
            AudioSource.clip = FootStepClip;
            AudioSource.Play();
        }
    }
    public void StopFootStepSE()
    {
        AudioSource.Stop();
    }
}
