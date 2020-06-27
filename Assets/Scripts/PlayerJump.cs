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
        player = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Quadrado"))
        {
            Debug.Log("está em cima de outro player!");
            playerMovement.isJumping = false;
            playerMovement.emCima = true;
        }
        playerMovement.isJumping = false;
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform")) {
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Platform")) {
            player.transform.parent = null;
            player.transform.localScale = new Vector3(1, 1, 1);
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
