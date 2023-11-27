using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Bola : MonoBehaviour
{
    GameObject player;
    public Tilemap tilemap;
    public Animator anim;

    void Start()
    {
  
        player = GameObject.Find("Pinguim");
    }


    void OnTriggerStay2D(Collider2D collision)
    {
    if (collision.transform.tag == "snow")
    {
            var cell = collision.gameObject.GetComponent<Tilemap>().WorldToCell(transform.position);

            if (GameManager.Instance.nevesUsadas.Contains(cell) == false)
            {
                
                print(cell + " pinguim " );
                GameManager.Instance.nevesUsadas.Add(cell);

                collision.gameObject.GetComponent<Tilemap>().SetTile(cell, GameManager.Instance.chaoSemNeve);
                StartCoroutine(VoltarNeve(cell));

                GameManager.Instance.AumentarPorcentagem(2);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "gelo")
        {
            if (collision.contacts.Length > 0)
            {
                print(player.GetComponent<Rigidbody2D>().velocity.x + " " + player.GetComponent<Rigidbody2D>().velocity.y);
                if (player.GetComponent<Rigidbody2D>().velocity.x >= 0 && player.GetComponent<Rigidbody2D>().velocity.y == 0) return;
                knockback(collision.contacts[0].point);
                
            }
            GameManager.Instance.AumentarPorcentagem(-4);
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        print("TESTE " + col.transform.name);
        if (col.transform.tag == "estilingue")
        {
            if(GameManager.Instance.porcentagemBola >= 100)
            {
                print("VITORIA ATIVADA");
                anim.SetBool("ativar", true);
                GameManager.Instance.AtivarVitoria(0);

            }
        }
    }


    void knockback(Vector2 obj)
    {
        Vector2 dist = ((Vector2)gameObject.transform.position - obj);
        dist.Normalize();
        player.GetComponent<Rigidbody2D>().AddForce(dist * 25);
    }

    IEnumerator VoltarNeve(Vector3Int cell)
    {
        yield return new WaitForSeconds(45f);
        tilemap.GetComponent<Tilemap>().SetTile(cell, GameManager.Instance.neve);

    }

    IEnumerator Catapulta()
    {
        anim.Play("ativando");
        yield return new WaitForSeconds(3);
        GameManager.Instance.AtivarVitoria(2);

    }
}
