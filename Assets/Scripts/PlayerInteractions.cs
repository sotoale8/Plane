using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{   
    public GameObject powerUp;
    public bool powerUpCollected;

    public GameObject slider;
    private bool alreadyEnable=false;

    void Start()
    {
       
    }
    void Update()
    {
       if(GameManager.Instance.playerPoints==6 && !alreadyEnable)
       {
         EnablePowerup();
       }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            powerUpCollected=true;
            slider.SetActive(true);

        }
    }
    public void EnablePowerup()
    {

          powerUp.SetActive(true);
          alreadyEnable=true;     

    }

}
