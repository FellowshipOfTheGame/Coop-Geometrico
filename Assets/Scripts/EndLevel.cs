using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    private bool ColisaoP1;
    private bool ColisaoP2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        /* Caso o player1 colida com a porta*/
        Debug.Log(other.gameObject.transform.parent.gameObject);

        if (Object.ReferenceEquals(Player1, other.gameObject.transform.parent.gameObject))
        {
            ColisaoP1 = true;
        }

        /* Caso o player2 colida com a porta*/

        if (Object.ReferenceEquals(Player2, other.gameObject.transform.parent.gameObject))
        {
            ColisaoP2 = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        /* Caso o player1 saia da porta*/
        if (Object.ReferenceEquals(Player1, other.gameObject.transform.parent.gameObject))
        {
            ColisaoP1 = false;
        }

        /* Caso o player2 saia da porta*/
        if (Object.ReferenceEquals(Player2, other.gameObject.transform.parent.gameObject))
        {
            ColisaoP2 = false;
        }
    }

    private void Update()
    {
        if (ColisaoP1 && ColisaoP2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
