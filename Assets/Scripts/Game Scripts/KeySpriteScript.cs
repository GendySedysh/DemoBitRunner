using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpriteScript : MonoBehaviour
{
    private RythmScript _rythmScript;
    private SpriteRenderer _renderer;

    void Start()
    {
        _rythmScript = GameObject.Find("Rythm Controller").GetComponent<RythmScript>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rythmScript.timeRythmPoint)
        {
            _renderer.color = Color.green;
        }
        else
        {
            _renderer.color = Color.white;
        }
        
    }
}
