using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuebraParede : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Triangulo" && other.relativeVelocity.magnitude > 6)
            gameObject.SetActive(false);
    }
}
