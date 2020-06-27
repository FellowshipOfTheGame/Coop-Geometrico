using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaObstaculo : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Obstaculo;
    private bool ColisaoP1 = false;
    private bool ColisaoP2 = false;


    private void OnTriggerEnter2D(Collider2D other) {
        /* Caso o player1 colida com a porta*/
        if(Object.ReferenceEquals(Player1, other.gameObject.transform.parent.gameObject))
        {
            ColisaoP1 = true;
        }

        /* Caso o player2 colida com a porta*/
        if(Object.ReferenceEquals(Player2, other.gameObject.transform.parent.gameObject))
        {
            ColisaoP2 = true;
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
            /* Ativa/Desativa o obstáculo */
            if(Obstaculo.activeSelf == false)
                Obstaculo.SetActive(true);
            else Obstaculo.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.L) && ColisaoP2 == true)
        {
            /* Ativa/Desativa o obstáculo */
            if(Obstaculo.activeSelf == false)
                Obstaculo.SetActive(true);
            else Obstaculo.SetActive(false);
        }
    }
}
