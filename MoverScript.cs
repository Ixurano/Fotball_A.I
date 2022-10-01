using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverScript : MonoBehaviour
{
    private float playerSpeed = 0.0940f;
    private float playerRotationSpeed = 0.520f;
    GameObject ball;
    GameObject ballFootBlue;
    bool hasBall;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
        ballFootBlue = GameObject.FindGameObjectWithTag("ballFootBlue");
        hasBall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBall)
        {
            ball.transform.position = ballFootBlue.transform.position;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, playerSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -playerSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, playerRotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -playerRotationSpeed, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "agentBlue")
        {
            ball.transform.position = ballFootBlue.transform.position;
            hasBall = true;
            Debug.Log("got ball");
        }
    }
    private void OnTriggerExit(Collider other)
    {   //lostTheBall
        if (other.gameObject.tag == "ball")
        {
            hasBall = false;
            Debug.Log("lost ball");
        }
    }
}
