using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : Singleton<GameManager>
{

    public TMPro.TextMeshProUGUI bola, tempo;
    public Tilemap tilemap;
    public GameObject tutorial;

    public int porcentagemBola;


    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {

        if (Input.anyKey)
        {
            tutorial.SetActive(false);
            Time.timeScale = 1;
        }

        int segundos = Mathf.FloorToInt(Time.time % 60);
        int timeLasting = 60 - segundos;

        if (segundos >=60)
        {
            Time.timeScale = 0;
        }

        tempo.text = timeLasting.ToString();
        


        

    }

    public void AumentarPorcentagem(int porc)
    {
        porcentagemBola += porc;
        bola.text = (porcentagemBola+porc).ToString() + "%";
    }
}
