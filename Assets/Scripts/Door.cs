using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField]
    private Transform openTarget;
    [SerializeField]
    private Transform closeTarget;
    [SerializeField]
    private float smoothTimeOpen = 2;
    [SerializeField]
    private float openSoundSpeed = 1;
    [SerializeField]
    private float smoothTimeClose = 0.2f;
    [SerializeField]
    private float closeSoundSpeed = 1;

    [SerializeField]
    private AudioClip openDoor;
    [SerializeField]
    private AudioClip closeDoor;

    [HideInInspector]
    public bool audioPlayed = true;
    private AudioSource audioSource;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.SmoothDamp(transform.position, openTarget.transform.position, ref velocity, smoothTimeOpen);
            if (!audioPlayed)
            {
                audioSource.clip = openDoor;
                audioSource.pitch = openSoundSpeed;
                audioSource.Play();
                audioPlayed = true;
            }
        }

        if (!isOpen)
        {
            transform.position = Vector3.SmoothDamp(transform.position, closeTarget.transform.position, ref velocity, smoothTimeClose);
            if (!audioPlayed)
            {
                audioSource.clip = closeDoor;
                audioSource.pitch = closeSoundSpeed;
                audioSource.Play();
                audioPlayed = true;
            }
        }
    }
}