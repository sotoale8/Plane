using UnityEngine;

public class BulletShoot : MonoBehaviour
{   
    private float cont;
    public float fireRate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

         cont += Time.deltaTime; 
        if (Input.GetKey(KeyCode.Space) && cont>fireRate)
        {
           GameObject bullet = BulletPool.Instance.UseBullet();
           bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
           bullet.SetActive(true);
           cont=0f;
        }
    }
}
