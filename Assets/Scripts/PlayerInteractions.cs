using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{   
    public GameObject powerUp;
    public bool powerUpCollected;

        
        void Update()
    {
        if (GameManager.Instance.playerPoints==6)
        {
            powerUp.SetActive(true);
            
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            powerUpCollected=true;
            print("Colectado");

        }
    }

}
