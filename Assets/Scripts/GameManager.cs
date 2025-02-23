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

    public TextMeshProUGUI enemiesText;
    public int enemiesLeft;
    [SerializeField] bool isPlayerWins=false;

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
        if (isPlayerWins)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                playerPoints=0;
                isPlayerWins=false;
            }
    }

    public void CountEnemies()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesText.text=playerPoints+ "/6";

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
