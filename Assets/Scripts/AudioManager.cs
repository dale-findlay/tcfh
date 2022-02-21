using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager audioManager;
    private Dictionary<string, AudioSource> audioSourceNames = new Dictionary<string, AudioSource>();

    List<AudioSource> fadeOutSources = new List<AudioSource>();

    public float audioFadeTime = 2.0f;
    public bool muted = false;
    
    public static string GenerateSourceName(string name)
    {
        return name + "-" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").GetHashCode();
    }

    private void Awake()
    {
        if (audioManager)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            audioManager = this;
            DontDestroyOnLoad(this);
        }
    }

    public void MuteSound()
    {
        muted = true;

        foreach(KeyValuePair<string, AudioSource> source in audioSourceNames)
        {
            source.Value.mute = true;
        }
    }

    public void UnmuteSound()
    {
        muted = false;

        foreach (KeyValuePair<string, AudioSource> source in audioSourceNames)
        {
            source.Value.mute = false;
        }
    }

    public AudioSource GetSource(string name)
    {
        if (audioSourceNames.ContainsKey(name))
        {
            return audioSourceNames[name];
        }
        else
        {
            Debug.Log("Audio Source " + name + " Doesnt Exist");
            return null;
        }
    }

    private IEnumerator RemoveAfter(string name, AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);

        audioSourceNames.Remove(name);
    }

    public AudioSource PushAndPlay(string name, AudioClip clip, bool loop = false, float volume = 0.15f)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.loop = loop;
        source.volume = volume;

        if(muted)
        {
            source.mute = true;
        }
        
        audioSourceNames.Add(name, source);
        
        if(!loop)
        {
            RemoveAfter(name, clip);
        }

        source.Play();

        return source;
    }

    public bool RemoveSource(string name)
    {
        Destroy(GetSource(name));
        bool b = audioSourceNames.Remove(name);

        return b;
    }

    public void RemoveFadeOut(string name)
    {
        AudioSource source = GetSource(name);

        fadeOutSources.Add(source);

        audioSourceNames.Remove(name);
    }

    private void RemoveSource(AudioSource source)
    {
        Destroy(source);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        List<AudioSource> removedSources = new List<AudioSource>();

        foreach (AudioSource source in fadeOutSources)
        {
            //Debug.Log(source.clip.name + " " + source.volume);
            if(source)
            source.volume = Mathf.Lerp(source.volume, 0, Time.deltaTime * audioFadeTime);

            if (source.volume <= 0.05)
            {
                removedSources.Add(source);
                RemoveSource(source);
            }

        }

        foreach (AudioSource source in removedSources)
        {
            fadeOutSources.Remove(source);
        }

    }
}
