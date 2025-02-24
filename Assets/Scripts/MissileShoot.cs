using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MissileShoot : MonoBehaviour
{
    public Rigidbody missilePrefab;
    public Vector3 planeVelocity;
    public Rigidbody planeRB;

    public float fireRate;
    public float contS;

    public PlayerInteractions playerInteractions;


    public bool tankAdquired;
    public Transform positionTank;

    void Start()
    {
        
        planeVelocity = planeRB.linearVelocity;
        playerInteractions = FindAnyObjectByType<PlayerInteractions>();   
    }

    // Update is called once per frame
    void Update()
    {   
        contS += Time.deltaTime; 
        if ( tankAdquired && playerInteractions.powerUpCollected && Input.GetKeyDown(KeyCode.B) && contS > fireRate)
        {
           Rigidbody newMissile = Instantiate(missilePrefab,transform.position,transform.rotation);
           newMissile.linearVelocity=planeVelocity;
           contS=0f;
                          
        }
    }
}
