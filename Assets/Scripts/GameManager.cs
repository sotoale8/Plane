using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

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
    }

    void Start()
    {
        CountEnemies();
    }

    void Update()
    {

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

}
