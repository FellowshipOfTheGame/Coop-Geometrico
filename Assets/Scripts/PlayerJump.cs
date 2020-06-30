using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    PlayerMovement playerMovement;
    private GameObject player;

    private Animator animator;

    private Animator animator_other;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        playerMovement = GetComponentInParent<PlayerMovement>();
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Quadrado"))
        {
            playerMovement.isJumping = false;
            playerMovement.emCima = true;
            animator_other = other.gameObject.GetComponent<Animator>();
            animator_other.SetBool("emCima",true);
        }
        playerMovement.isJumping = false;
        animator.SetBool("isJumping", false);

        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform")) {

        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Platform")) {
            player.transform.parent = null;
            player.transform.localScale = new Vector3(2, 2, 2);
        }

        if(other.gameObject.CompareTag("Quadrado"))
        {
            playerMovement.emCima = false;
            animator_other = other.gameObject.GetComponent<Animator>();
            animator_other.SetBool("emCima",false);
        }

        if(other.gameObject.CompareTag("Triangulo"))
        {
            playerMovement.emCima = false;
        }
    }
}
