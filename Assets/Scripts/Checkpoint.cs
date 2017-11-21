using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	[HideInInspector]
	public bool isActive = false;

    private Animator animator;
    private AudioSource audioSource;

    public static GameObject currentChekpoint;

    void Start ()
	{
		animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (isActive)
		{
			animator.SetBool("IsActive", isActive);
		}
		else if (!isActive)
		{
			animator.SetBool("IsActive", !isActive);
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player" && !isActive )
		{
			isActive = true;
            audioSource.Play();

            currentChekpoint.GetComponent<Checkpoint>().isActive = false;
            //currentChekpoint = GetComponent<Checkpoint>(). FIX FIX FIX
		}
	}
}
