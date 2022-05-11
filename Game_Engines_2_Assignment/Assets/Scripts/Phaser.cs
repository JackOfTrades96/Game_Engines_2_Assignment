using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phaser : MonoBehaviour
{
    public float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 100);
        Debug.Log("Phaser");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
