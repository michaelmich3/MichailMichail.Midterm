using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartManager : MonoBehaviour
{
    [SerializeField]
    public static int heartsAmount = 3;
    [SerializeField]
    List<GameObject> hearts;

    public static bool isDead;
    private bool died = false;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject loseText;

    [SerializeField]
    private GameObject mainCamera;

    private Animator animator;
    private CircleCollider2D circleCollider2D;
    private BoxCollider2D boxCollider2D;
    private CameraController cameraController;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
        circleCollider2D = player.GetComponent<CircleCollider2D>();
        boxCollider2D = player.GetComponent<BoxCollider2D>();
        cameraController = mainCamera.GetComponent<CameraController>();
    }

    void Update()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i <= (heartsAmount - 1))
                hearts[i].SetActive(true);
            else
                hearts[i].SetActive(false);
        }

        if (heartsAmount < 0)
        {
            isDead = true;
        }

        if (isDead && !died)
        {
            animator.SetBool("isDead", true);
            player.transform.Rotate(0, 0, -45);
            circleCollider2D.enabled = false;
            boxCollider2D.enabled = false;
            cameraController.enabled = false;
            loseText.SetActive(true);
            died = true;
        }
    }
}