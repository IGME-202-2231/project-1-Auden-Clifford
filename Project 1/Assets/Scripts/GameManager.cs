using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Menu,
    Gameplay,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    // only needed in game scene
    [SerializeField] private TextMesh playerRotation;
    [SerializeField] private TextMesh playerSpeed;
    [SerializeField] private TextMesh scoreDisplay;
    [SerializeField] private TextMesh roundDisplay;
    [SerializeField] private TextMesh EnemiesDisplay;

    // only needed in menu scene
    [SerializeField] private CanvasRenderer menuPanel;
    [SerializeField] private CanvasRenderer helpPanel;
    [SerializeField] private CanvasRenderer gameUIPanel;
    [SerializeField] private CanvasRenderer gameOverPanel;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyStandardPrefab;
    [SerializeField] private GameObject enemyShooterPrefab;
    

    private GameObject player;
    private List<GameObject> enemies = new List<GameObject>();

    public GameState currentState = GameState.Menu;

    private int round = 1;
    private int score = 0;

    private float markerRadius = 4;

    /// <summary>
    /// Gets or sets the game object that the player controls
    /// </summary>
    public GameObject Player { get { return player; } set { player = value; } }

    /// <summary>
    /// Gets a list of each enemy in the game
    /// </summary>
    public List<GameObject> Enemies { get { return enemies; } }

    /// <summary>
    /// Gets or sets the score this game
    /// </summary>
    public int Score { get { return score; } set { score = value; } }

    private void Start()
    {
        // set all panels except menu to hide at beginning
        menuPanel.gameObject.SetActive(true);
        helpPanel.gameObject.SetActive(false);
        gameUIPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case GameState.Menu:

                break;

            case GameState.Gameplay:
                // display player info
                playerRotation.text = "Rotation Speed: " + player.GetComponent<PhysicsObject>().AngularVelocity;
                playerSpeed.text = "Speed: " + player.GetComponent<PhysicsObject>().Velocity.magnitude;
                scoreDisplay.text = "Score: " + score;
                roundDisplay.text = "Round: " + round;
                EnemiesDisplay.text = "Enemies: " + enemies.Count;

                DrawMarkers();

                // spawn new enemies if the player destroyed all current ones
                if(enemies.Count == 0)
                {
                    // give the player an extra speed boost for finishing the round
                    player.GetComponent<PhysicsObject>().SpeedUpSpin(round * 10);

                    round++;
                    SpawnEnemies(round);
                }

                break;

            case GameState.GameOver:
                break;
        }
        
    }

    /// <summary>
    /// Opens the help panel
    /// </summary>
    public void OpenHelp()
    {
        helpPanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// Closes the help panel
    /// </summary>
    public void CloseHelp()
    {
        helpPanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// This function is called if the player quits beck to the menu screen
    /// </summary>
    public void QuitToMenu()
    {
        currentState = GameState.Menu;
        menuPanel.gameObject.SetActive(true);
        gameUIPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// This function is called whenever the player starts a new game
    /// </summary>
    public void StartGame()
    {
        menuPanel.gameObject.SetActive(false);
        gameUIPanel.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);

        // instantiate a new player for the scene
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        // reset game values
        score = 0;
        round = 1;

        // spawn new enemies
        SpawnEnemies(round);

        currentState = GameState.Gameplay;
    }

    /// <summary>
    /// This function is called when the player is destroyed, signals the program to end the game
    /// </summary>
    public void GameOver()
    {
        currentState = GameState.GameOver;
        menuPanel.gameObject.SetActive(false);
        gameUIPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);

        // clear any lefover enemies
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    /// <summary>
    /// Spawns a random number of shooter and standard enemies in a gaussian distribution around the player
    /// </summary>
    /// <param name="baseNumber">minimum number of enemies to spawn</param>
    private void SpawnEnemies(int baseNumber)
    {
        int numEnemies = Random.Range(baseNumber, baseNumber + 3);

        for(int i = 0; i < numEnemies; i++)
        {
            enemies.Add(Instantiate(
                enemyStandardPrefab,
                new Vector3(
                    Gaussian(player.transform.position.x, 20),
                    Gaussian(player.transform.position.y, 20),
                    0), Quaternion.identity));
        }

        // for every 5 normal enemies that spawn, 1 shooter enemy will spawn
        for (int i = 0; i < numEnemies / 5; i++) 
        {
            enemies.Add(Instantiate(
                enemyShooterPrefab,
                new Vector3(
                    Gaussian(player.transform.position.x, 20),
                    Gaussian(player.transform.position.y, 20),
                    0), Quaternion.identity));
        }

        /*
        Instantiate(enemyShooterPrefab, new Vector3(10, 10, 0), Quaternion.identity);
        Instantiate(enemyStandardPrefab, new Vector3(-10, -10, 0), Quaternion.identity);
        */
    }

    public void Damage()
    {

    }

    /// <summary>
    /// Get a random number with gaussian distribution
    /// </summary>
    /// <param name="mean">the mean value</param>
    /// <param name="stdDev">the standard deviation from the mean</param>
    /// <returns>a random float with gaussian distribution</returns>
    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

    private void DrawMarkers()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().Marker.transform.position = player.transform.position + (enemy.transform.position - player.transform.position).normalized * markerRadius;
        }
    }
}
