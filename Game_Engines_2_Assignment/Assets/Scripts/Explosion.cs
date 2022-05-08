using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    public GameObject ship;
    [SerializeField]
    public float explosionPower;
    [SerializeField]
    public AudioSource explosionAudio;
    [SerializeField]
    public ParticleSystem explosion;


    public void Start()
    {
        Explode();
        ship.SetActive(false);



    }

    public void Explode()
    {
        explosion.Play();
    }
        

}
