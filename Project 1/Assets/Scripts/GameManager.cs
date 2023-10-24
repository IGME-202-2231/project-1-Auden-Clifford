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

    private GameObject player;
    private List<GameObject> enemies = new List<GameObject>();

    public GameState currentState = GameState.Menu;

    /// <summary>
    /// Gets or sets the game object that the player controls
    /// </summary>
    public GameObject Player { get { return player; } set { player = value; } }

    /// <summary>
    /// Gets a list of each enemy in the game
    /// </summary>
    public List<GameObject> Enemies { get { return enemies; } }

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
                EnemiesDisplay.text = "Enemies: " + enemies.Count;
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

    public void StartGame()
    {
        currentState = GameState.Gameplay;
        menuPanel.gameObject.SetActive(false);
        gameUIPanel.gameObject.SetActive(true);
    }
}
