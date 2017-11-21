using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private Sprite buttonUp;
    [SerializeField]
    private Sprite buttonDown;
    [SerializeField]
    private GameObject targetDoor;
    [SerializeField]
    private GameObject colliderBlock;
    [SerializeField]
    private GameObject crateCollider;
    [SerializeField]
    private AudioClip buttonUpSound;
    [SerializeField]
    private AudioClip buttonDownSound;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Crate")
        {
            if (colliderBlock != null)
                colliderBlock.SetActive(true);
            if (crateCollider != null)
            crateCollider.SetActive(false);
        }
        if (collider.tag == "Crate" && targetDoor != null || collider.tag == "Player" && targetDoor != null)
        {
            targetDoor.GetComponent<Door>().isOpen = true;
            targetDoor.GetComponent<Door>().audioPlayed = false;
            spriteRenderer.sprite = buttonDown;
            audioSource.clip = buttonDownSound;
            audioSource.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Crate" && targetDoor != null  || collider.tag == "Player" && targetDoor != null)
        {
            targetDoor.GetComponent<Door>().isOpen = false;
            targetDoor.GetComponent<Door>().audioPlayed = false;
            spriteRenderer.sprite = buttonUp;
            audioSource.clip = buttonUpSound;
            audioSource.Play();
        }
    }
}
