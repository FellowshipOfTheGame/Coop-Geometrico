using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player1;
    GameObject Player2;
    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
    }
    
    // Update is called once per frame
    private float y;
    private float x;
    void Update()
    {
        y = (Player1.transform.position.y + Player2.transform.position.y) /2;
        x = (Player1.transform.position.x + Player2.transform.position.x) /2;
        Debug.Log("x: "+x+" y: "+y);
        gameObject.transform.position = new Vector3(x, y, 0);
    }
}
