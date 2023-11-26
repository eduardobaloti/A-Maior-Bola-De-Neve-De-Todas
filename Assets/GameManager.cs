using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TMPro.TextMeshProUGUI bola, tempo;
    public GameObject tutorial;


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



        tempo.text = timeLasting.ToString();





    }
}
