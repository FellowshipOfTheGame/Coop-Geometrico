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
    private Vector3 ultimaPos1;
    private Vector3 ultimaPos2;

    public Animator animator;
    private Animator animator_child;

    private Transform playerChild;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        //animator_child = GetComponentInChildren<Animator>();

        playerChild = this.gameObject.transform.GetChild(0);
        animator_child = playerChild.GetComponent<Animator>();

        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        if(playerChild.tag == "Quadrado")
        {
            Debug.Log("É quadrado meu!");
            animator_child.SetBool("isQuadrado", true);
            animator_child.SetBool("isTriangulo", false);
            animator_child.SetBool("isCirculo", false);
        }

        if(playerChild.tag == "Triangulo")
        {
            Debug.Log("É triangulo meu!");
            animator_child.SetBool("isQuadrado", false);
            animator_child.SetBool("isTriangulo", true);
            animator_child.SetBool("isCirculo", false);
        }

        if(playerChild.tag == "Circulo")
        {
            Debug.Log("É circulo meu!");
            animator_child.SetBool("isQuadrado", false);
            animator_child.SetBool("isTriangulo", false);
            animator_child.SetBool("isCirculo", true);
        }
    }



    // Update is called once per frame
    void Update()
    {
        playerChild = this.gameObject.transform.GetChild(0);
        animator_child = playerChild.GetComponent<Animator>();

        if(gameObject.name == "Player1")
        {
            if(Input.GetButton("Jump") && !isJumping) {
                isJumping = true;
                rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpForce));
                animator_child.SetBool("isJumping", true);
            }

            if(emCima)
            {
                var dist = p2.transform.position - ultimaPos2;
                p1.transform.position+= new Vector3(dist.x,0,0);
            }

            move = Input.GetAxis("Horizontal");

            rigidbody.velocity = new Vector3(move*playerSpeed, rigidbody.velocity.y);

            if(move < 0)
            {
                animator_child.SetFloat("speed",(move*-1));
                transform.eulerAngles = new Vector3(0, 180, 0);
            } else if(move > 0)
            {
                animator_child.SetFloat("speed",move);
                transform.eulerAngles = new Vector3(0, 0, 0);
            } else if(move == 0)
                animator_child.SetFloat("speed",(float)0);
            ultimaPos2 = p2.transform.position;
        }

        if(gameObject.name == "Player2")
        {
            if(Input.GetButton("Jump2") && !isJumping) {
                isJumping = true;
                rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpForce));
                animator_child.SetBool("isJumping", true);
            }

            if(emCima)
            {
                var dist = p1.transform.position - ultimaPos1;
                p2.transform.position+= new Vector3(dist.x,0,0);
            }

            move = Input.GetAxis("Horizontal2");

            rigidbody.velocity = new Vector3(move*playerSpeed, rigidbody.velocity.y);

            if(move < 0)
            {
                animator_child.SetFloat("speed",(move*-1));
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if(move > 0)
            {
                animator_child.SetFloat("speed",move);
                transform.eulerAngles = new Vector3(0, 0, 0);
            } else if(move == 0)
                animator_child.SetFloat("speed",(float)0);


            ultimaPos1 = p1.transform.position;
        }

        if(playerChild.tag == "Quadrado")
        {
            Debug.Log("É quadrado meu!");
            animator_child.SetBool("isQuadrado", true);
            animator_child.SetBool("isTriangulo", false);
            animator_child.SetBool("isCirculo", false);
        }

        if(playerChild.tag == "Triangulo")
        {
            Debug.Log("É triangulo meu!");
            animator_child.SetBool("isQuadrado", false);
            animator_child.SetBool("isTriangulo", true);
            animator_child.SetBool("isCirculo", false);
        }

        if(playerChild.tag == "Circulo")
        {
            Debug.Log("É circulo meu!");
            animator_child.SetBool("isQuadrado", false);
            animator_child.SetBool("isTriangulo", false);
            animator_child.SetBool("isCirculo", true);
        }

    }



}