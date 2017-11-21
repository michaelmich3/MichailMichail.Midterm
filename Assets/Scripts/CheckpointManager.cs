using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject startingCheckpoint;

    public static GameObject currentChekpoint;

    private float countdown;

    void Start()
    {
        currentChekpoint = startingCheckpoint;
        currentChekpoint.GetComponent<Checkpoint>().isActive = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("LoadCheckpoint") && !HeartManager.isDead && countdown <= 0)
        {
            if (HeartManager.heartsAmount > 0)
            {
                player.transform.position = currentChekpoint.transform.position;
            }
            HeartManager.heartsAmount -= 1;
            countdown = 3;
        }

        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
    }
}
