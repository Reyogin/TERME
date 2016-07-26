using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour
{

    public Maze mazePrefab;
    private Maze mazeInstance;

    public Player playerPrefab;
    private Player playerInstance;

    private void Start()
    {
        //1BeginGame();

        StartCoroutine(BeginGame());
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // a chanmger avec un restrd en gardant la position du player a chaque interval de temps

        {
            RestartGame();
        }
    }

    /*private void BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        //mazeInstance.Generate();
        StartCoroutine(mazeInstance.Generate());
    }*/

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
