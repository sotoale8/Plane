using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int playerPoints = 0;
    public int pointsToWin=1;
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


}
