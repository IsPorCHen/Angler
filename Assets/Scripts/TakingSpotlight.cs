using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingSpotlight : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool isFollowing = false;
    private bool playerInRange = false;

    private Vector3 offset; 

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            isFollowing = !isFollowing; 

            if (isFollowing)
            {
                offset = transform.position - player.transform.position;
            }
        }

        if (isFollowing && player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
