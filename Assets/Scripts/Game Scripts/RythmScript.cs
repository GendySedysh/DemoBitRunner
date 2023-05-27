using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmScript : MonoBehaviour
{
    public bool timeRythmPoint;
    public bool rythmPoint;
    public int bitNumber;
    public int wholeNote;
    private float _halfBeat;
    private float _fullBeat;
    private float _lastBeat;
    private bool _isBeatStrong;
    private float _songPosition;

    private MusicControllerScript _musicScript;

    // Start is called before the first frame update
    void Start()
    {
        timeRythmPoint = false;
        rythmPoint = false;
        bitNumber = 1;
        wholeNote = 0;

        _musicScript = GameObject.FindGameObjectWithTag("Music Controller").GetComponent<MusicControllerScript>();
        _fullBeat = _musicScript.secPerBeat;
        _halfBeat = _fullBeat / 2.0f;
        _lastBeat = _halfBeat;
        _songPosition = _musicScript.songPosition;
    }

    // Update is called once per frame
    void Update()
    {
        _songPosition = _musicScript.songPosition;

        RythmPointsUpdate();
        RythmTimeUpdate();
    }

    private void RythmPointsUpdate()
    {
        if (_songPosition > _lastBeat + _halfBeat)
        {
            _lastBeat += _halfBeat;
            
            rythmPoint = true;
            if (bitNumber == 8)
                bitNumber = 0;
            bitNumber += 1;
        }
        else
        {
            rythmPoint = false;
        }
    }

    private void RythmTimeUpdate()
    {
        if (Mathf.Abs(_songPosition - (_lastBeat + _halfBeat)) < 0.1f) // Горит в течении 0.1 секунды
        {
            timeRythmPoint = true;
        }
        else
        {
            timeRythmPoint = false;
        }
    }
}
