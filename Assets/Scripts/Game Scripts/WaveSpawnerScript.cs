using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject _groundPrefab;
    [SerializeField] private GameObject _enemyPrefab;

    public void SpawnGround()
    {
        GameObject ground = Instantiate(_groundPrefab, transform.position, transform.rotation);
        ground.transform.parent = GameObject.Find("Spawned Ground").transform;
    }

    public void SpawEnemy()
    {
        GameObject enemy = Instantiate(_enemyPrefab, transform.position + new Vector3(0.15f, 1f, 0f), transform.rotation);
        enemy.transform.parent = GameObject.Find("Spawned Enemies").transform;
    }

    public void ChangeSpawnPosition(int num)
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + (num * 2), transform.position.z);

        transform.position = newPosition;
    }
}
