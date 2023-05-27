using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteArray;
    static char [] _possibleKeys = new char[3] {'q', 'w', 'e'};
    [SerializeField] private bool _canBeDestroy;
    [SerializeField] private char _keyToDestroy;
    private HeroScript _heroScript;

    void Start()
    {
        GenerateKeySequence();
        _canBeDestroy = false;

        _heroScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroScript>();
    }

    private void GenerateKeySequence()
    {
        int n = Random.Range(0, 3);

        _keyToDestroy = _possibleKeys[n];
        Transform child = transform.GetChild(0);
        child.GetComponent<SpriteRenderer>().sprite = spriteArray[n];
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Key Checkbox")
        {
            _canBeDestroy = true;
        }
        
        if (col.gameObject.name == "Player")
        {
            _heroScript.getDamage();
            Destroy(gameObject);
        }
    }

    private char CharToUpper(char c)
    {
        return c.ToString().ToUpperInvariant()[0];
    }

    public char GetKeyToDestroy()
    {
        return _keyToDestroy;
    }

    public bool GetEnemyCanBeDestroy()
    {
        return _canBeDestroy;
    }
}
