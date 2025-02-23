using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{   
    public GameObject powerUp;
    public bool powerUpCollected;

    private bool alreadyEnable=false;

        
        void Update()
    {
       if(GameManager.Instance.playerPoints==1 && !alreadyEnable)
       {
         EnablePowerup();
       }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            powerUpCollected=true;

        }
    }
    public void EnablePowerup()
    {

          powerUp.SetActive(true);
          alreadyEnable=true;

    }

}
