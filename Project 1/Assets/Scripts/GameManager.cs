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

                // spawn new enemies if the player destroyed all current ones
                if(enemies.Count == 0)
                {
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

    public void QuitToMenu()
    {
        currentState = GameState.Menu;
        menuPanel.gameObject.SetActive(true);
        gameUIPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        currentState = GameState.Gameplay;
        menuPanel.gameObject.SetActive(false);
        gameUIPanel.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);

        // instantiate a new player for the scene
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        // reset game values
        score = 0;
        round = 1;

        // spawn new ones
        SpawnEnemies(round);
    }

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

    private void SpawnEnemies(int baseNumber)
    {
        Instantiate(enemyShooterPrefab, new Vector3(10, 10, 0), Quaternion.identity);
        Instantiate(enemyStandardPrefab, new Vector3(-10, -10, 0), Quaternion.identity);
    }

    public void Damage()
    {

    }
}
