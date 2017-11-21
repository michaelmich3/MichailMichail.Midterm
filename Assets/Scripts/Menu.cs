using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private Object startScene;
    [SerializeField]
    private GameObject creditsButton;
    [SerializeField]
    private GameObject backButton;
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject backTarget;
    [SerializeField]
    private float timeBack = 1;
    [SerializeField]
    private GameObject creditsTarget;
    [SerializeField]
    private float timeCredits = 1;
    [SerializeField]
    private GameObject startGameTarget;
    [SerializeField]
    private float timeStartGame = 1;

    [SerializeField]
    private GameObject targetCamera;
    [SerializeField]
    private GameObject backCameraTarget;
    [SerializeField]
    private float timeBackCamera = 1;
    [SerializeField]
    private GameObject creditsCameraTarget;
    [SerializeField]
    private float timeCreditsCamera = 1;

    private string targetName;
    private SpriteRenderer spriteRenderer;
    private Vector3 playerVelocity = Vector3.zero;
    private Vector3 cameraVelocity = Vector3.zero;

    private float timer = 0;
    private int clickedButton;

    private void Start()
    {
        spriteRenderer = character.GetComponent<SpriteRenderer>();
        HeartManager.heartsAmount = 3;
        HeartManager.isDead = false;
    }

    public void Credits()
    {
        if (!spriteRenderer.flipX)
            spriteRenderer.flipX = true;
        targetName = "creditsTarget";
    }

    public void Back()
    {
        if (spriteRenderer.flipX)
            spriteRenderer.flipX = false;

        targetName = "backTarget";
    }

    public void StartGame()
    {
        if (spriteRenderer.flipX)
            spriteRenderer.flipX = false;

        targetName = "startGameTarget";
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (targetName == "creditsTarget")
        {
            creditsButton.SetActive(false);
            startButton.SetActive(false);
            character.transform.position = Vector3.SmoothDamp(character.transform.position, creditsTarget.transform.position, ref playerVelocity, timeCredits);
            targetCamera.transform.position = Vector3.SmoothDamp(targetCamera.transform.position, creditsCameraTarget.transform.position, ref cameraVelocity, timeCreditsCamera);
            clickedButton = 1;
        }
        if (targetName == "backTarget")
        {
            backButton.SetActive(false);
            character.transform.position = Vector3.SmoothDamp(character.transform.position, backTarget.transform.position, ref playerVelocity, timeBack);
            targetCamera.transform.position = Vector3.SmoothDamp(targetCamera.transform.position, backCameraTarget.transform.position, ref cameraVelocity, timeBackCamera);
            clickedButton = 2;
        }
        if (targetName == "startGameTarget")
        {
            creditsButton.SetActive(false);
            startButton.SetActive(false);
            backButton.SetActive(false);
            character.transform.position = Vector3.SmoothDamp(character.transform.position, startGameTarget.transform.position, ref playerVelocity, timeStartGame);
            targetCamera.transform.position = Vector3.SmoothDamp(targetCamera.transform.position, backCameraTarget.transform.position, ref cameraVelocity, timeBackCamera);
            clickedButton = 3;
        }

        if (clickedButton == 1)
        {
            Timer(3, backButton, null, null);
        }
        if (clickedButton == 2)
        {
            Timer(3, creditsButton, startButton, null);
        }
        if (clickedButton == 3)
        {
            Timer(3, null, null, startScene);
        }
    }

    private void Timer(float timeWait, GameObject button1, GameObject button2, Object scene)
    {
        if (timer >= timeWait)
        {
            timer = 0;
            if (button1 != null)
            {
                button1.SetActive(true);
            }
            if (button2 != null)
            {
                button2.SetActive(true);
            }
            if (scene != null)
            {
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
