using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
 
    public int playerPoints = 0;
    public int pointsToWin=1;   

     public int enemiesLeft;
     public int tankEnemiesLeft;

     public int totalEnemies;

  
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
        CountEnemies();

     
    }

    void Start()
    {

    }

       public void AddPlayerPoint()
    {
        playerPoints++;
    }
     
    public void CountEnemies()
    {   
        
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
       
        tankEnemiesLeft= GameObject.FindGameObjectsWithTag("Tank").Length;
        
        totalEnemies=enemiesLeft+tankEnemiesLeft;
        //isPlayerWins= tankEnemiesLeft + enemiesLeft == 0;      

        if (isPlayerWins)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                playerPoints=0;
                isPlayerWins=false;
            }
    }
 

}
