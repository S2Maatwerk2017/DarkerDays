using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{


    public AudioSource SfxSource;
    public AudioSource MusicSource;
    public static SFXManager Instance;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    public bool SoundPlayed { get; set; }           


	// Use this for initialization
	void Awake ()
	{
	    if (Instance == null)
	    {
	        Instance = this;
	    }else if (Instance != this)
	    {
	        Destroy(gameObject);
	    }
        DontDestroyOnLoad(gameObject);
	}


    public void PlaySingle(List<AudioClip> clips)
    {
        //if (!SfxSource.isPlaying)
        //{
            SfxSource.clip = clips[Random.Range(0, clips.Count-1)];
            SfxSource.Play();
        //}
    }

    public void PlaySingle(AudioClip clip)
    {
        //if (!SfxSource.isPlaying)
        //{
            SfxSource.clip = clip;
            SfxSource.Play();
        //}
    }

    public void RandomizeSfx(List<AudioClip> clips)
    {
        int randomindex = Random.Range(0, clips.Count -1);
        SfxSource.clip = clips[randomindex];
        SfxSource.pitch = Random.Range(lowPitchRange, highPitchRange);
        SfxSource.Play();
    }
}
