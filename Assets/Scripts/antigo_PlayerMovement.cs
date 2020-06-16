using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antigo_PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    // 40f por padrão
    float horizontalMove;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //animator.SetFloat("xSpeed", Mathf.Abs(horizontalMove)); // Caso tenha animação de andar

        // Lembrar de setar os botões de pulo,e de andar direita e esquerda
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Pulou");
            jump = true;
            //animator.SetBool("isJumping", true); // Caso tenha animação de pulo
        }

        if (Input.touchCount > 0)
        {
                Touch touch = Input.GetTouch(0);

                float direcao = (touch.position.x) > (Screen.width / 2) ? 1 : -1; // Verifica a direção que o personagem vai andar
                horizontalMove = direcao * runSpeed;
                //animator.SetFloat("xSpeed", Mathf.Abs(horizontalMove)); // Caso tenha animação de andar

            if ((Input.touchCount > 1))
            {
                jump = true;
                //animator.SetBool("isJumping", true); // Caso tenha animação de pulo
            }
        }

    }

    public void OnLanding()
    {
        //animator.SetBool("isJumping", false); //Desativa pulo CASO tenha animação
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void OnTriggerEnter2D(Collider2D other) {
            Debug.Log("colidiu com plataforma");

        if(other.gameObject.CompareTag("Platform")) {
            player.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Platform")) {
            player.transform.parent = null;
        }
    }

}