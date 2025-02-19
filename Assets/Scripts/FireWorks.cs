using Unity.VisualScripting;
using UnityEngine;

public class FireWorks : MonoBehaviour
{       
    private Transform[] fireWorks;


    void Awake()
    {
      fireWorks = GetComponentsInChildren<Transform>();
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           foreach (Transform fireWork in transform)
               {
                    fireWork.gameObject.SetActive(true);
               }
        }
    }

}
