using UnityEngine;

public class TankBehavior : MonoBehaviour
{   
    public ParticleSystem explosionEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {   
            explosionEffect.Play();
            gameObject.GetComponent<MeshRenderer>().enabled=false;
            gameObject.GetComponent<Collider>().enabled=false;
            foreach (MeshRenderer renderer in gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                renderer.enabled=false;
            }
            GameManager.Instance.CountEnemies();
            Destroy(this.gameObject,3f);
            GameManager.Instance.AddPlayerPoint();
        }
    }


}
