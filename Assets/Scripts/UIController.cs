using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
     [SerializeField] bool isPaused;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionsPanel;

    public TextMeshProUGUI tankEnemiesText;
    
    public TextMeshProUGUI enemiesText;
     public GameObject landEnableText;
     public GameObject slider;

    public GameObject finalPos;
   

     public bool gameStarted=false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CountEnemiesUI();
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

            if (GameManager.Instance.enemiesLeft+GameManager.Instance.tankEnemiesLeft+GameManager.Instance.playerPoints!=13)
            {
             GameManager.Instance.CountEnemies();
             CountEnemiesUI();
            }

           

    if (GameManager.Instance.totalEnemies==0)
       {
        slider.SetActive(false);
       if(!finalPos.activeSelf)
       {
        landEnableText.SetActive(true);
       }
       else
       {
        landEnableText.SetActive(false);

       }
       
       }

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

       public void CountEnemiesUI()
    {   
        
        enemiesText.text=GameManager.Instance.enemiesLeft.ToString();     
        tankEnemiesText.text = GameManager.Instance.tankEnemiesLeft.ToString();

      
    }
 
}
