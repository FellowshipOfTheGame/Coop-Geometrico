using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    PlayerMovement playerMovement;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        /*if(other.CompareTag("Player1"))
        {
            Debug.Break();
        }*/
        playerMovement.isJumping = false;

        if(other.gameObject.CompareTag("Platform"))
            player.transform.parent.gameObject.transform.parent.gameObject.transform.parent = other.gameObject.transform;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Platform")) {
            player.transform.parent.gameObject.transform.parent.gameObject.transform.parent = null;
        }

        if(other.gameObject.CompareTag("Quadrado"))
        {
            playerMovement.emCima = false;
        }

        if(other.gameObject.CompareTag("Triangulo"))
        {
            Debug.Log("Saiu do player 2");
            playerMovement.emCima = false;
        }
    }
}
