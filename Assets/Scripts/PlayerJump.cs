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
        Debug.Log(other.name);
        /*if(other.CompareTag("Player1"))
        {
            Debug.Break();
        }*/
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
                playerMovement.emCima = true;
            }
        }
        if(gameObject.tag == "Player2" && playerMovement.isJumping)
        {
            if(other.gameObject.CompareTag("Player1"))
            {
                Debug.Log("está em cima de outro player!");
                playerMovement.isJumping = false;
                playerMovement.emCima = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Platform")) {
            player.transform.parent = null;
        }
        if(other.gameObject.CompareTag("Player1"))
        {
            
            playerMovement.emCima = false;
        }
        if(other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("Saiu do player 2");
            playerMovement.emCima = false;
        }
    }
}
