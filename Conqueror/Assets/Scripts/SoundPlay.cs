using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour

{
    public AudioSource crash;
    public AudioSource jump;

    public void PlayCrash()
    {
        crash.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            crash.Play();
        }

        if (collision.collider.tag == "Fly")
        {
            jump.Play();
        }
    }
}
