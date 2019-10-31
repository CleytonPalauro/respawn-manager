using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RespawnPoints : MonoBehaviour
{
    // Recebe o personagem que vai ter a posição monitorada.
    public GameObject myPlayer;
    
    // Recebe todos os respawn.
    public GameObject[] respawns;

    // Armazena as distancias
    private float[] distances;

    // Aemazena a primeira posição do indice ativo.
    private int indexOn = 0;

    void Start()
    {
        // Desabilita todos os GameObjects do Array respawns[].
        DisableAllRespawn(respawns);
        
        // Habilita o primeiro respawn.
        respawns[indexOn].SetActive(true);

        // Inicializa uma nova instancia.
        distances = new float[respawns.Length];
    }

    void Update()
    {
        // Armazena a distancia entre o player e todos os pontos de respawn.
        for (int i = 0; i < respawns.Length; i++)
        {
            distances[i] = Vector3.Distance(myPlayer.transform.position, respawns[i].transform.position);
        }
        
        // Retorna o indice do menor valor encontrado no Array distances[].
        indexOn = Array.IndexOf(distances, Mathf.Min(distances));

        // Desabilita todos os GameObjects do Array respawns[].
        DisableAllRespawn(respawns);

        // Habilita todos os GameObjects do Array respawns[].
        respawns[indexOn].SetActive(true);
    }

    // Método para atualizar a posição do personagem de acordo com o respawn mais próximo.
    public void UpdatePosition()
    {
        myPlayer.transform.position = respawns[indexOn].transform.position;
    }

    // Método para desabilitar todos os GameObjects de um Array.
    public void DisableAllRespawn(Array myArray)
    {
        foreach (GameObject go in myArray)
        {
            go.SetActive(false);
        }
    }
}
