using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuebraParede : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private Animator animator;

    public bool broke;

    void Start() {
        broke = false;
        animator = GetComponentInParent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Triangulo" && other.relativeVelocity.magnitude > 4)
        {
            Debug.Log("Colidiu!");
            animator.SetBool("break",true);
        }
    }

    void Update() {
        if(broke==true)
        {
            animator.SetBool("broke",true);
        }
    }
}
