using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaPersonagem : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject NovoPrefab;
    public bool ColisaoP1 = false;
    public bool ColisaoP2 = false;

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
            /* Troca o personagem */
            Destroy(Player2.transform.GetChild(0).gameObject);
            var PlayerTrocado = Instantiate(NovoPrefab, Player2.transform.position, Quaternion.identity);
            PlayerTrocado.transform.parent = Player2.transform;
        }

        if(Input.GetKeyDown(KeyCode.L) && ColisaoP2 == true)
        {
            /* Troca o personagem */
            Destroy(Player2.transform.GetChild(0).gameObject);
            var PlayerTrocado = Instantiate(NovoPrefab, Player2.transform.position, Quaternion.identity);
            PlayerTrocado.transform.parent = Player2.transform;
        }
    }
}
