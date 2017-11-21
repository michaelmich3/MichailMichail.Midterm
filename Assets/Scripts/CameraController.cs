using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float dampTime = 0.2f;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float centerX = 0.5f;
    [SerializeField]
    private float centerY = 0.5f;
    [SerializeField]
    private float minFallSpeed= 8f;
    [SerializeField]
    private float lookDownValue = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (player)
        {
            Vector3 aheadPoint = player.position + new Vector3(player.GetComponent<Rigidbody2D>().velocity.x / 2, 0, 0);
            if (player.GetComponent<Rigidbody2D>().velocity.y <= -minFallSpeed)
            {
                aheadPoint += new Vector3(0, (lookDownValue * player.GetComponent<Rigidbody2D>().velocity.y), 0);
            }
            Vector3 point = Camera.main.WorldToViewportPoint(aheadPoint);
            Vector3 delta = aheadPoint - Camera.main.ViewportToWorldPoint(new Vector3(centerX, centerY, point.z));
            Vector3 destination = transform.position + (delta * 1);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
