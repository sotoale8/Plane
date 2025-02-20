using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    public int poolSize;
    public  GameObject bulletPrefab;
    [SerializeField]  List<GameObject> bulletCharged= new List<GameObject>();
     private Transform spawBulletPoint;
    public static BulletPool Instance{ get; private set;}


    void Awake()
    {
        if(Instance== null)
            {   
                Instance=this;
               
            }
        else
        {
            Destroy(this.gameObject);
        }
    }


    void Start()
    {
     spawBulletPoint=FindAnyObjectByType<BulletShoot>().transform;
     MakePool(poolSize); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
                   
    public void MakePool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletCharged.Add(bullet);
            bullet.transform.parent=transform;
        }    
    }

      

    public GameObject UseBullet()
    {
        for (int i = 0; i < bulletCharged.Count; i++)
        {
            if (!bulletCharged[i].activeInHierarchy)
            {   
                return bulletCharged[i];
            }

        }
        MakePool(1);
        return bulletCharged.Last();
    }

}
