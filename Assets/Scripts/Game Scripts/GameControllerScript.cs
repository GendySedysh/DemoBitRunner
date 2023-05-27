using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using RythmData;

public class GameControllerScript : MonoBehaviour
{
    private RythmScript _rythmScript;
    private WaveSpawnerScript _waveSpawnerScript;
    private List<bool> _spawnedEnemyList;
    private bool _spawnDelay = false;
    private int _counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rythmScript = GameObject.Find("Rythm Controller").GetComponent<RythmScript>();
        _waveSpawnerScript = GameObject.FindGameObjectWithTag("Wave Spawner").GetComponent<WaveSpawnerScript>();

        _spawnedEnemyList = new List<bool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rythmScript.rythmPoint)
        {
            SpawnerPositionChanger();
            _waveSpawnerScript.SpawnGround();
            MoveObjectsWithTag("Ground");

            MoveObjectsWithTag("Enemy");
            SpawnEnemy();
        }
    }

    private void SpawnerPositionChanger()
    {
        if (_spawnedEnemyList.Count >= 5 && Random.Range(0, 100) % 10 == 0)
        {
            int n = Random.Range(-1, 2);
            if (n != 0)
            {
                _waveSpawnerScript.ChangeSpawnPosition(n);
                _spawnDelay = true;
            }
        }
    }

    private void SpawnEnemy()
    {
        if (!_spawnDelay)
        {
            if (Random.Range(0, 100) % 3 == 0)
            {
                _waveSpawnerScript.SpawEnemy();
                _spawnedEnemyList.Clear();
            }
            else
            {
                _spawnedEnemyList.Add(false);
            }
        }
        else
        {
            _counter++;
        }

        if (_counter >= 3)
        {
            _counter = 0;
            _spawnDelay = false;
        }
    }

    private void MoveObjectsWithTag(string _tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(_tag);

        foreach (GameObject tagObj in taggedObjects)
        {
            tagObj.transform.position += new Vector3(-1, 0, 0);
            if (tagObj.transform.position.x <= -10)
            {
                Destroy(tagObj);
            }
        }
    }
}
