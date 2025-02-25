using System;
using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{   
    public float shootVelocity;
    private Rigidbody bulletRigidBody;
   
    public Vector3 initialPosition;


    void Awake()
    {
        
        bulletRigidBody= GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
     
        bulletRigidBody.linearVelocity=Vector3.zero;
        bulletRigidBody.angularVelocity= Vector3.zero;
        StartCoroutine(DisableBullet());
    }

    // Update is called once per frame
    void Update()
    {
        bulletRigidBody.linearVelocity= shootVelocity * transform.forward;
    }

    IEnumerator  DisableBullet()
    {
        yield return new WaitForSeconds(5f);
        gameObject.transform.SetPositionAndRotation(Vector3.zero,Quaternion.identity);
        gameObject.SetActive(false);

        
    }


    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

}
