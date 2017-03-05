
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource efxSource;
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.


    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        efxSource = gameObject.AddComponent<AudioSource>();

    }


    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {

        // Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();

    }

    //Used to play single sound clips delayed.
    public void PlaySingleDelayed(AudioClip clip, float delay)
    {

        // Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.PlayDelayed(delay);

    }

    public void PlaySoundLoop(AudioClip audioClip)
    {

        musicSource.clip = audioClip;
        musicSource.loop = true;
        musicSource.Play();

    }

    public void StopSound()
    {
        musicSource.Stop();
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}