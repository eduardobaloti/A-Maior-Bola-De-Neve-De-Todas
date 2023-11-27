using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : Singleton<GameManager>
{

    public TMPro.TextMeshProUGUI bola, tempo;
    public Tilemap tilemap;
    public GameObject tutorial, derrota, vitoria;
    public List<Vector3Int> nevesUsadas = new List<Vector3Int>();
    public Tile neve, chaoSemNeve;
    public AudioSource audio;


    private float tempoDecorrido = 0f;
    private float duracaoContagem = 60f; // Tempo em segundos
    bool jogoGanho;

    public int porcentagemBola;
    int fase;


    void Start()
    {
        StartCoroutine(WaitStart());
    }

    void Update()
    {

        if (Input.anyKey)
        {
            tutorial.SetActive(false);
            Time.timeScale = 1;
            StartCoroutine(Contador());
        }

        int segundos = Mathf.FloorToInt(Time.timeSinceLevelLoad % 60);
        int timeLasting = 60 - segundos;

        tempo.text = timeLasting.ToString();
        
    }

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }


    public void AumentarPorcentagem(int porc)
    {
        if (porcentagemBola + porc > 100 || porcentagemBola + porc < 1) return;
        porcentagemBola += porc;
        bola.text = (porcentagemBola+porc).ToString() + "%";
    }
    public void AtivarVitoria(int ind)
    {
        audio.Stop();
        jogoGanho = true;
        derrota.SetActive(false);
        StopCoroutine(Contador());
        vitoria.SetActive(true);
        derrota.SetActive(false);
        fase += 1;
    }

    public void ProximaFase()
    {
        Menu.Instance.LoadGameInd(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AtivarDerrota()
    {
        audio.Stop();
        if (jogoGanho) return;
        fase = 1;
        derrota.SetActive(true);
    }

    public IEnumerator Contador()
    {
        yield return new WaitForSecondsRealtime(60f);
        print("Derrota");
        AtivarDerrota();
    }



}
