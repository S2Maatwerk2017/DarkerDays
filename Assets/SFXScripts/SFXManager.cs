using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{


    public AudioSource SfxSource;
    public AudioSource MusicSource;
    public static SFXManager instance = null;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;



	// Use this for initialization
	void Awake () {

	    if (instance == null)
	    {
	        instance = this;
	    }
        else if (instance != this)
	    {
	        Destroy(this);
	    }
        DontDestroyOnLoad(this);

	}

    public void PlaySingle(AudioClip clip)
    {
        SfxSource.clip = clip;
        SfxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        SfxSource.pitch = randomPitch;
        SfxSource.clip = clips[randomIndex];
        SfxSource.Play();
    }
}
