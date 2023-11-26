using System.Net.Http.Headers;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{

    Rigidbody2D rb2;
    float moveSpeed = .5f;
    float pesoBola = 0.005f;

    public GameObject[] bolasDeNeve;
    public Sprite[] pinguimSprites;


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            var charPos = transform.position.y;
            charPos += moveSpeed;
            rb2.AddForce(transform.up *- moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            var charPos = transform.position.y;
            charPos += moveSpeed;
            rb2.AddForce(transform.up * moveSpeed/5);
        }

        if (rb2.velocity.magnitude > pesoBola)
        {
            float inputRotacao = Input.GetAxis("Horizontal");
            float rotacaoTotal = inputRotacao * 1;
            //print("inputRotacao " + inputRotacao + " rotacaoTotal " + rotacaoTotal);
            transform.Rotate(Vector3.forward, rotacaoTotal);
        }

        var pos = transform.rotation.eulerAngles.z;

        if      (pos > 0 & pos < 45) gameObject.GetComponent<SpriteRenderer>().sprite = pinguimSprites[0];
        else if (pos > 45 & pos < 90) gameObject.GetComponent<SpriteRenderer>().sprite = pinguimSprites[1];
        else if (pos > 90 & pos < 135) gameObject.GetComponent<SpriteRenderer>().sprite = pinguimSprites[2];
        else if (pos > 135 & pos < 180) gameObject.GetComponent<SpriteRenderer>().sprite = pinguimSprites[3];
        else if (pos > 180 & pos < 225) gameObject.GetComponent<SpriteRenderer>().sprite = pinguimSprites[4];
        else if (pos > 225 & pos < 270) gameObject.GetComponent<SpriteRenderer>().sprite = pinguimSprites[5];
        else if (pos > 270 & pos < 315) gameObject.GetComponent<SpriteRenderer>().sprite = pinguimSprites[6];
        else if (pos > 315 & pos < 360) gameObject.GetComponent<SpriteRenderer>().sprite = pinguimSprites[7];


        var porcBola = GameManager.Instance.porcentagemBola;
        if (porcBola > 0 & porcBola < 25)
        {
            pesoBola = 0.005f;
            gameObject.GetComponent<Rigidbody2D>().mass = 0.75f;
            bolasDeNeve[1].SetActive(false);
            bolasDeNeve[0].SetActive(true);
        }
        else if (porcBola > 25 & porcBola < 50)
        {
            pesoBola = 0.01f;

            gameObject.GetComponent<Rigidbody2D>().mass = 1.25f;

            bolasDeNeve[2].SetActive(false);
            bolasDeNeve[0].SetActive(false);
            bolasDeNeve[1].SetActive(true);
        }
        else if (porcBola > 50 & porcBola < 75)
        {
            pesoBola = 0.015f;

            gameObject.GetComponent<Rigidbody2D>().mass = 1.75f;

            bolasDeNeve[3].SetActive(false);
            bolasDeNeve[1].SetActive(false);
            bolasDeNeve[2].SetActive(true);
        }
        else if (porcBola > 75 & porcBola < 99)
        {
            pesoBola = 0.02f;

            gameObject.GetComponent<Rigidbody2D>().mass = 2.25f;

            bolasDeNeve[2].SetActive(false);
            bolasDeNeve[4].SetActive(false);
            bolasDeNeve[3].SetActive(true);
        }
        else if (porcBola > 99)
        {
            pesoBola = 0.025f;
            gameObject.GetComponent<Rigidbody2D>().mass = 3f;
            bolasDeNeve[3].SetActive(false);
            bolasDeNeve[4].SetActive(true);
        }

    }

    
}
