using Unity.VisualScripting;
using UnityEngine;

public class MissileShoot : MonoBehaviour
{
    public Rigidbody missilePrefab;
    public Vector3 planeVelocity;
    public Rigidbody planeRB;

    public float fireRate;
    public float contS;


    void Start()
    {
        planeVelocity = planeRB.linearVelocity;
       
    }

    // Update is called once per frame
    void Update()
    {   
        contS += Time.deltaTime; 
        if (Input.GetKeyDown(KeyCode.Space) && contS > fireRate)
        {
           Rigidbody newMissile = Instantiate(missilePrefab,transform.position,transform.rotation);
           newMissile.linearVelocity=planeVelocity;
           contS=0f;
                          
        }
    }
}
