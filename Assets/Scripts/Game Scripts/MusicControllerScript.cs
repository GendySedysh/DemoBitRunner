using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControllerScript : MonoBehaviour
{
    private AudioSource musicSource;
    [SerializeField] private float songBpm = 60f;
    public float secPerBeat;
    private float dspSongTime;
    private float firstBeatOffset = 0.2f;
    public float songPosition;
    
    void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
    }

    void Start()
    {
        musicSource.Play();
    }

    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
    }
}
