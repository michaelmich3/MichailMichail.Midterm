using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float maxSpeed =10f;
	bool facingRight = true;

	Animator anim;

	bool grounded = false;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundRadius = 0.12f;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float jumpForce = 500;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip runSound;
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip jumpVoiceSound;
    [SerializeField]
    private List<AudioClip> landSound;
    private AudioClip landSoundClip;

    void Start ()
	{
		anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
	
	void FixedUpdate ()
	{
        if (!HeartManager.isDead)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("Ground", grounded);

            anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(move)); //changes the speed value of the animator

            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }

            if (move > 0 || move < 0)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = runSound;
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    IEnumerator waitForSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    void Update()
	{
        if (!HeartManager.isDead)
        {
            if (grounded && Input.GetButtonDown("Jump"))
            {
                anim.SetBool("Ground", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

                audioSource.clip = jumpSound;
                audioSource.Play();

                StartCoroutine(waitForSeconds(0.5f));
                audioSource.clip = jumpVoiceSound;
                StartCoroutine(waitForSeconds(0.5f));
                audioSource.Play();
            }
        }
    }

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!HeartManager.isDead)
        {
            if (grounded)
            {
                int index = Random.Range(0, landSound.Count);
                landSoundClip = landSound[index];
                audioSource.clip = landSoundClip;
                audioSource.Play();
            }
        }
    }
}
