using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Animator anim;
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Goal");
    }

    public void PlaySound()
    {
        source.Play();
    }
}
