using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objColision : MonoBehaviour
{
    private bool colisao = false;
    private string tipoPorta;
    // Start is called before the first frame update
    void Start()
    {
        /* Determina a tipo de peça que pode entrar na porta */
        if(gameObject.tag == "PortaTriangulo")
            tipoPorta = "Triangulo";

        if(gameObject.tag == "PortaQuadrado")
            tipoPorta = "Quadrado";

        if(gameObject.tag == "PortaCirculo")
            tipoPorta = "Circulo";
    }

    private void OnTriggerEnter2D(Collider2D other) {
        colisao = true;
        Debug.Log(colisao);
    }

    private void OnTriggerExit2D(Collider2D other) {
        colisao = false;
        Debug.Log(colisao);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && colisao == true)
            Debug.Log("entrou na porta");

    }
}
