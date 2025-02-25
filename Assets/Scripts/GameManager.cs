using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] bool isPaused;
    public bool gameStarted=false; 
    public int playerPoints = 0;
    public int pointsToWin=1;   

    public TextMeshProUGUI tankEnemiesText;
     public int tankEnemiesLeft;
    public TextMeshProUGUI enemiesText;
    public int enemiesLeft;
    [SerializeField] bool isPlayerWins=false;

    public static GameManager Instance {get; private set;}

    void Awake()
    {
        if (Instance== null)
            {
                Instance=this;
             
            }
        else
            {
                Destroy(this.gameObject);
            }

        Time.timeScale = 0; 

        menuPanel= GameObject.Find("Menu");
     
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

        if (enemiesLeft+tankEnemiesLeft+playerPoints!=13)
            {
             CountEnemies();
            }
    }

    public void AddPlayerPoint()
    {
        playerPoints++;
    }

    public void CountEnemies()
    {   
        
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesText.text=enemiesLeft.ToString();

        tankEnemiesLeft= GameObject.FindGameObjectsWithTag("Tank").Length;
        tankEnemiesText.text = tankEnemiesLeft.ToString();

        isPlayerWins= tankEnemiesLeft + enemiesLeft == 0;      

        if (isPlayerWins)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                playerPoints=0;
                isPlayerWins=false;
            }
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

    public void OptionsMenu()
    {
        optionsPanel.SetActive(true);

    }

      public void BackMenu()
    {
        optionsPanel.SetActive(false);

    }
    
        public void EndGame()
    {   

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameStarted=false;

    }   

  

}
