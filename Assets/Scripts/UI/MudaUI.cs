using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudaUI : MonoBehaviour
{
    public GameObject PlayerUI;
    public Sprite ImagemQuadrado;
    public Sprite ImagemTriangulo;
    public Sprite ImagemCirculo;
    private Image UISprite;

    private void Start() {
        UISprite = PlayerUI.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount > 0)
        {
            if (transform.GetChild(0).gameObject.tag == "Quadrado")
                UISprite.sprite = ImagemQuadrado;

            else if (transform.GetChild(0).gameObject.tag == "Triangulo")
                UISprite.sprite = ImagemTriangulo;

            else if (transform.GetChild(0).gameObject.tag == "Circulo") {
                UISprite.sprite = ImagemCirculo;
            }
        }
    }
}
