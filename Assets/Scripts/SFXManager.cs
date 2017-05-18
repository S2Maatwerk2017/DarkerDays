using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{


    public AudioSource SfxSource;
    public AudioSource DefaultBGM;
    public AudioSource TempBGM;
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

    public void SingleSfx(AudioClip clip)
    {
        SfxSource.clip = clip;
        SfxSource.Play();
    }

    public void RandomizeSfx(List<AudioClip> clips)
    {
        int randomindex = Random.Range(0, clips.Count);
        SfxSource.clip = clips[randomindex];
        SfxSource.pitch = Random.Range(lowPitchRange, highPitchRange);
        SfxSource.Play();
    }

    public void PlayDifferentBMG(AudioClip clip)
    {
        DefaultBGM.Stop();
        TempBGM.clip = clip;
        TempBGM.loop = true;
        TempBGM.Play();
    }

    public void PlayDefaultBMG()
    {
        TempBGM.Stop();
        DefaultBGM.loop = true;
        DefaultBGM.Play();
    }

    public void StopAllSounds()
    {
        if (DefaultBGM.isPlaying)
        {
            DefaultBGM.Stop();
        }
        if (TempBGM.isPlaying)
        {
            TempBGM.Stop();
        }
        if (SfxSource.isPlaying)
        {
            SfxSource.Stop();
        }
    }
}
