using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private Object nextScene;

    [SerializeField]
    private bool loadOnCollisionEnter = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && loadOnCollisionEnter)
        {
            SceneManager.LoadScene(nextScene.name);
        }
    }

    public void onClick()
    {
        SceneManager.LoadScene(nextScene.name);
    }
}
