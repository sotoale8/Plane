using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] bool isPaused;
    private bool gameStarted=false; 
    public int playerPoints = 0;
    public int pointsToWin=1;   

    public TextMeshProUGUI enemiesText;
    public int enemiesLeft;

    public static GameManager Instance {get; private set;}

    void Awake()
    {
        if (Instance== null)
            {
                Instance=this;
                DontDestroyOnLoad(this.gameObject);

            }
        else
            {
                Destroy(this.gameObject);
            }

        Time.timeScale = 0;
    }

    void Start()
    {
        CountEnemies();

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void AddPlayerPoint()
    {
        playerPoints++;
        if (playerPoints==pointsToWin)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                playerPoints=0;
            }
    }

    public void CountEnemies()
    {
        enemiesLeft =playerPoints;
        enemiesText.text=enemiesLeft +"/6";

    }

    public void PauseGame()
    {
        if(!gameStarted) return;
        
        isPaused=!isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pausePanel.SetActive(isPaused);
        AudioManager.Instance.PauseMusic(isPaused);
      
        
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1;
        gameStarted= true;

    }

}
