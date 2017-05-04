using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{


    public AudioSource SfxSource;
    public AudioSource MusicSource;
    public static SFXManager instance;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    public bool SoundPlayed { get; set; }           


	// Use this for initialization
	void Awake () {

	}


    public void PlaySingle(List<AudioClip> clips)
    {
        //if (!SfxSource.isPlaying)
        //{
            SfxSource.clip = clips[Random.Range(0, clips.Count)];
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
        int randomIndex = Random.Range(0, clips.Count-1);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        SfxSource.pitch = randomPitch;
        SfxSource.clip = clips[randomIndex];
        SfxSource.Play();
    }
}
