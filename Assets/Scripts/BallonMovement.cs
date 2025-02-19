using UnityEngine;


public class BallonMovement : MonoBehaviour
{
       public float positionMax; 
       public float positionMin; 
         private bool isUp= true;

       public float velMovement;

       public AudioClip soundClip;  
       public AudioSource audioSource;

       public ParticleSystem explosionEffect;

    void Start()
    {

    }

    void Update()
    {   
        if(transform.position.y<=positionMax && isUp)
            {
             transform.Translate(Time.deltaTime * velMovement * Vector3.up);
             if (transform.position.y>=positionMax)
                {
                    isUp=!isUp;
                }
            }
        else
            {
             transform.Translate(Time.deltaTime * velMovement * Vector3.down); 
              if (transform.position.y<=positionMin)
                {
                    isUp=!isUp;
                }
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Missile"))
        {   
            audioSource.PlayOneShot(soundClip);
            
            foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
                {  
                     if (meshRenderer!=null)
                    {
                        meshRenderer.enabled=false;

                    }
                }

             foreach (Collider collider in gameObject.GetComponentsInChildren<Collider>())
                {  
                     if (collider!=null)
                    {
                        collider.enabled=false;

                    }
                }    
                
            GameManager.Instance.AddPlayerPoint();
            GameManager.Instance.CountEnemies();
            explosionEffect.Play();
            Destroy(other.gameObject);
            Destroy(gameObject,3f);
          
        }

    }


}
