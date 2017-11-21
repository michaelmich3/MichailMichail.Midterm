using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField]
    private AudioClip crateDrag;
    [SerializeField]
    private AudioClip crateHit;

    private AudioSource audioSource;
    private Rigidbody2D thisRigidBody;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        thisRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (thisRigidBody.velocity.magnitude >= 0.2 && !audioSource.isPlaying)
        {
            audioSource.clip = crateDrag;
            audioSource.Play();
        }
        else if (thisRigidBody.velocity.magnitude < 0.2)
        {
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            audioSource.clip = crateHit;
            audioSource.Play();
        }
    }
}
