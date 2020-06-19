using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public GameObject player;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ground") && playerMovement.isJumping) {
            playerMovement.isJumping = false;
        }

        if(other.gameObject.CompareTag("Platform") && playerMovement.isJumping) {
            playerMovement.isJumping = false;
            player.transform.parent = other.gameObject.transform;
        }
        if(gameObject.tag == "Player1" && playerMovement.isJumping)
        {
            if(other.gameObject.CompareTag("Player2"))
            {
                Debug.Log("está em cima de outro player!");
                playerMovement.isJumping = false;
                player.transform.parent = other.gameObject.transform;
            }
        }
        if(gameObject.tag == "Player2" && playerMovement.isJumping)
        {
            if(other.gameObject.CompareTag("Player1"))
            {
                Debug.Log("está em cima de outro player!");
                playerMovement.isJumping = false;
                player.transform.parent = other.gameObject.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Platform")) {
            player.transform.parent = null;
        }
    }
}
