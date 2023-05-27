using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheckboxScript : MonoBehaviour
{
    [SerializeField] private Transform _playerCoord;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, _playerCoord.position.y, transform.position.z);
    }
}
