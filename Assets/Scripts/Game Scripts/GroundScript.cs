using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color[] pick_one = new Color[4] {Color.blue, Color.yellow, Color.green, Color.white};

        GetComponent<SpriteRenderer>().color = pick_one[Random.Range(0, 4)];
    }
}
