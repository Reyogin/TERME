﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    public Maze mazePrefab;
    private Maze mazeInstance;

    private float CD;
    public Player playerPrefab;
    private Player playerInstance;
    public Texture IMG;

    bool loading;

    private void Start()
    {
        //1BeginGame();
        
        StartCoroutine(BeginGame());
        this.loading = true;
    }

    private IEnumerator BeginGame()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;//camera own background
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);//overlay map

        mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());
        playerInstance = Instantiate(playerPrefab) as Player;
        playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));

        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
    }

    private void OnGUI()
    {
        if (loading)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), IMG);
        }
    }

       

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // a chanmger avec un restrd en gardant la position du player a chaque interval de temps

        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            loading = false;


        //cheatcode pour acceder au credit de fin
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene("Credits");
    }



    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        if (playerInstance != null)
        {
            Destroy(playerInstance.gameObject);
        }
        StartCoroutine(BeginGame());
    }
}