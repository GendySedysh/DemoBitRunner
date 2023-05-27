using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform _playerCoord;
    private int targetFrameRate = 60;
 
     private void Start()
     {
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = targetFrameRate;
     }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, _playerCoord.position.y, transform.position.z);
    }
}
