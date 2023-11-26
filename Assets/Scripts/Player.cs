using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{

    Rigidbody2D rb2;
    float moveSpeed = .25f;
    float pesoBola = 0.02f;
    public GameObject[] bolasDeNeve;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
               

        if (Input.GetKey(KeyCode.W))
        {
            var pos = transform.position.y;
            pos += moveSpeed;
            rb2.AddForce(transform.up *- moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            var pos = transform.position.y;
            pos += moveSpeed;
            rb2.AddForce(transform.up * moveSpeed/5);
        }


        if (rb2.velocity.magnitude > pesoBola)
        {
            float inputRotacao = Input.GetAxis("Horizontal");
            float rotacaoTotal = inputRotacao * 1;
            transform.Rotate(Vector3.forward, rotacaoTotal);

        }
    }
}
