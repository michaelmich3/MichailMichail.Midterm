using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static int coins;
    [SerializeField]
    Text text;

    private AudioSource audioSource;
    private bool soundPlayed = false;

    void Awake ()
    {
        text.GetComponent<Text>();
        coins = 0;
        audioSource = GetComponent<AudioSource>();
    }

	void Update ()
    {
        text.text = coins.ToString();

        if (coins >= 10 && !soundPlayed)
        {
            audioSource.Play();
            soundPlayed = true;
        }
	}
}
