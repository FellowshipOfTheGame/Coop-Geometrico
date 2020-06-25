using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntraPorta : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public Transform TeleportPosition;
    private bool ColisaoP1 = false;
    private bool ColisaoP2 = false;
    private string tipo;

    // Start is called before the first frame update
    void Start()
    {
        /* Determina a tipo de peça que pode entrar na porta */
        if(gameObject.tag == "PortaTriangulo")
            tipo = "Triangulo";

        else if(gameObject.tag == "PortaQuadrado")
            tipo = "Quadrado";

        else if(gameObject.tag == "PortaCirculo")
            tipo = "Circulo";
    }

    private void OnTriggerEnter2D(Collider2D other) {
        /* Caso o player1 colida com a porta*/
        if(Player1.transform.GetChild(0).tag == tipo)
        {
            if(Object.ReferenceEquals(Player1, other.gameObject.transform.parent.gameObject))
            {
                ColisaoP1 = true;
            }
        }


        /* Caso o player2 colida com a porta*/
        if(Player2.transform.GetChild(0).tag == tipo)
        {
            if(Object.ReferenceEquals(Player2, other.gameObject.transform.parent.gameObject))
            {
                ColisaoP2 = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        /* Caso o player1 saia da porta*/
        if(Object.ReferenceEquals(Player1, other.gameObject.transform.parent.gameObject))
        {
            ColisaoP1 = false;
        }

        /* Caso o player2 saia da porta*/
        if(Object.ReferenceEquals(Player2, other.gameObject.transform.parent.gameObject))
        {
            ColisaoP2 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && ColisaoP1 == true)
        {
            /* Teleporta o personagem */
            Player1.transform.position = new Vector2 (TeleportPosition.position.x, TeleportPosition.position.y);
        }

        if(Input.GetKeyDown(KeyCode.L) && ColisaoP2 == true)
        {
            /* Teleporta o personagem */
            Player2.transform.position = new Vector2 (TeleportPosition.position.x, TeleportPosition.position.y);
        }
    }
}
