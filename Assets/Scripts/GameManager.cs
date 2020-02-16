using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const float Y = -0.75f;
    [SerializeField] List<GameObject> enemies;

    private GameObject titleScreen;
    public GameObject gameBallPrefab;
    Vector3 playerPosAtSpawn = new Vector3(0, Y, -3);
    Vector3 ballPosAtSpawn = new Vector3(0, Y, 1);
    
    private int obstacleCount = 6;

    private int goals;
    public bool gameActive;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.Find("Title Screen");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Generate a random spawn position for obstacles & enemies
    private Vector3 GenerateSpawnPos()
    {
        float spawnX = Random.Range(-12, 12);
        float spawnZ = Random.Range(10, 20);

        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);

        return randomPos;
    }

    //Spawn obstacles
    private void SpawnObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            Instantiate(enemies[0], GenerateSpawnPos(), transform.rotation);
        }
    }
    
    //Spawn enemies
    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemies[enemiesToSpawn], GenerateSpawnPos(), enemies[enemiesToSpawn].transform.rotation);
        }
    }

    //Update goal counter after scored
    public void UpdateGoals(int goalsToAdd)
    {
        goals += goalsToAdd;
        scoreText.text = "Goals: " + goals;
    }

    public void ExitGame()
    {
        //Resets the scene again to title screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        exitButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    //Respawn player after score
    public void Respawn()
    {
        transform.position = playerPosAtSpawn;
        Instantiate(gameBallPrefab, ballPosAtSpawn, transform.rotation);
    }

    //Called after difficulty selection
    public void StartGame(int difficulty)
    {
        //Used to send info to other classes
        gameActive = true;

        //Spawn game ball
        Instantiate(gameBallPrefab, ballPosAtSpawn, transform.rotation);

        if (difficulty == 0)
        {
            SpawnObstacles();
        }
        else
        {
            SpawnEnemyWave(difficulty);
        }

        //Hide title screen after start
        titleScreen.gameObject.SetActive(false);
        //Display the exit button and the goal counter
        exitButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }
}
