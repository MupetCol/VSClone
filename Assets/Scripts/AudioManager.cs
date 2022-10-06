using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using DG.Tweening;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private bool replaceTheme;

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        if (instance == null)
            instance = this;
		else if (replaceTheme)
		{
			instance.StopPlaying(instance.sounds[0].name);
			Destroy(instance);
			instance = this;
			Play(sounds[0].name);
			return;
		}
		else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


    }

    void Start()
    {
        Play(sounds[0].name);
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not founnd!");
            return;
        }
        s.source.Play();
    }

    public void StartSwap(string currentlyPlaying, string newClip) 
    { 
        StartCoroutine(SwapAudio(currentlyPlaying, newClip));
    }

    public IEnumerator SwapAudio(string currentlyPlaying, string newClip)
	{
        Sound s1 = Array.Find(sounds, sound => sound.name == currentlyPlaying);
        Sound s2 = Array.Find(sounds, sound => sound.name == newClip);

        if (s1 == null || s2 == null)
        {
            Debug.LogWarning("Sound: " + name + "not founnd!");
        }
        s1.source.DOFade(0, 2f);
        s2.volume = 0;
        s2.source.Play();
        yield return new WaitForSeconds(.5f);
        s2.source.DOFade(.5f, 2f);
        yield return new WaitForSeconds(2f);
        s1.source.Stop();
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not founnd!");
            return;
        }
        s.source.Stop();
    }

}

