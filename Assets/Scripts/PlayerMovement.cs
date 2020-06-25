using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    public bool isJumping;
    public bool emCima;
    private float move;
    private Rigidbody2D rigidbody;
    public GameObject p1;
    public GameObject p2;
    //public Animator animator;
    private Vector3 ultimaPos1;
    private Vector3 ultimaPos2;
    private Transform playerChild;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        /*if(playerChild.tag == "Quadrado")
        {
            animator.SetBool("isQuadrado", true);
            animator.SetBool("isTriangulo", false);
            animator.SetBool("isCirculo", false);
        }

        if(playerChild.tag == "Triangulo")
        {
            animator.SetBool("isQuadrado", false);
            animator.SetBool("isTriangulo", true);
            animator.SetBool("isCirculo", false);
        }

        if(playerChild.tag == "Circulo")
        {
            animator.SetBool("isQuadrado", false);
            animator.SetBool("isTriangulo", false);
            animator.SetBool("isCirculo", true);
        }*/
    }



    // Update is called once per frame
    void Update()
    {

        if(gameObject.name == "Player1")
        {

            if(emCima)
            {
                Debug.Log("Em cima player1");
                var dist = p2.transform.position - ultimaPos2;
                p1.transform.position+= new Vector3(dist.x,0,0);
            }

            move = Input.GetAxis("Horizontal");

            rigidbody.velocity = new Vector3(move*playerSpeed, rigidbody.velocity.y);

            if(move < 0)
            {
                //animator.SetFloat("speed",(move*-1));
                transform.eulerAngles = new Vector3(0, 180, 0);
            } else if(move > 0)
            {
                //animator.SetFloat("speed",move);
                transform.eulerAngles = new Vector3(0, 0, 0);
            } else if(move == 0)
                //animator.SetFloat("speed",(float)0);

            if(Input.GetButton("Jump") && !isJumping) {
                Debug.Log("pulou");
                rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpForce));
                isJumping = true;
            }
            ultimaPos2 = p2.transform.position;
        }

        if(gameObject.name == "Player2")
        {
            if(emCima)
            {
                Debug.Log("Em cima player2");
                var dist = p1.transform.position - ultimaPos1;
                p2.transform.position+= new Vector3(dist.x,0,0);
            }

            move = Input.GetAxis("Horizontal2");

            rigidbody.velocity = new Vector3(move*playerSpeed, rigidbody.velocity.y);

            if(move < 0)
            {
                //animator.SetFloat("speed",(move*-1));
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if(move > 0)
            {
                //animator.SetFloat("speed",move);
                transform.eulerAngles = new Vector3(0, 0, 0);
            } else if(move == 0)
                //animator.SetFloat("speed",(float)0);

            if(Input.GetButton("Jump2") && !isJumping) {
                Debug.Log("pulou");
                rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpForce));
                isJumping = true;
            }
            ultimaPos1 = p1.transform.position;
        }

        if(gameObject.tag == "Circulo")
        {

        }

    }



}
