using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Bola : MonoBehaviour
{
    public Tile neve, chaoSemNeve;
    List<Vector3Int> nevesUsadas = new List<Vector3Int>();
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Pinguim");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "snow")
        {
            var cell = collision.gameObject.GetComponent<Tilemap>().WorldToCell(transform.position);
            if (!nevesUsadas.Contains(cell))
            {
                nevesUsadas.Add(cell);
                

                collision.gameObject.GetComponent<Tilemap>().SetTile(cell, chaoSemNeve);
                GameManager.Instance.AumentarPorcentagem(2);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "gelo")
        {
            GameManager.Instance.AumentarPorcentagem(-5);
            knockback(collision);
        }
    }


    void knockback(Collision2D obj)
    {
        Vector2 dist = (gameObject.transform.position - obj.transform.position);
        dist.Normalize();
        player.GetComponent<Rigidbody2D>().AddForce(dist * 50);
    }
}
