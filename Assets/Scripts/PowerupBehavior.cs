using UnityEngine;

public class PowerupBehavior : MonoBehaviour
{   
  

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          // Destroy(gameObject); 
           gameObject.SetActive(false);
            
        }
    }

}
