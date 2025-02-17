using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerRigidbody : MonoBehaviour
{   
     Rigidbody playerRb;
     private float speed;
    public float normalSpeed=10;
    public float turboSpeed=20;
    public float breakSpeed=20;
    public float takingOffSpeed=20;
    public float speedController;
    public  float  horizontal;
    public  float  vertical;

    public float rotationxForce;
    public float rotationyForce;
    public float rotationzForce;

    public bool isTakingOff;
    
    void Start()
    {
      playerRb= GetComponent<Rigidbody>();
      isTakingOff=false;
    }
    void Update()
    {
        horizontal=Input.GetAxis("Horizontal");
        vertical=Input.GetAxis("Vertical");
        CheckTurbo(); 

    }
    private void CheckTurbo()
    {
       if (Input.GetKey(KeyCode.LeftShift))
        {
            speed=turboSpeed;
        } 
      else
        {
            speed=normalSpeed;
        }
           
    }
    private void RotatePlane()
        {
        playerRb.AddRelativeTorque(horizontal*Time.fixedDeltaTime*rotationyForce*Vector3.up,ForceMode.Force);
        playerRb.AddRelativeTorque(vertical*Time.fixedDeltaTime*rotationxForce*Vector3.right,ForceMode.Force);
       if (Input.GetKey(KeyCode.E))
       {
        playerRb.AddRelativeTorque(Time.fixedDeltaTime*rotationzForce*-Vector3.forward,ForceMode.Force);
        
       }
       
       if (Input.GetKey(KeyCode.Q))
       {
        playerRb.AddRelativeTorque(Time.fixedDeltaTime*rotationzForce*Vector3.forward,ForceMode.Force);
        
       }

        }
    private void AcelerateAndBrakePlane()
    {
        if (Input.GetKey(KeyCode.C) && isTakingOff)
       {   
            if(speedController>15f)
                  {
                    playerRb.AddRelativeForce(breakSpeed * Time.fixedDeltaTime * Vector3.back, ForceMode.VelocityChange);        
                  }
            playerRb.useGravity=true;
       }
       else if (isTakingOff)
       {
            playerRb.useGravity=false;
            playerRb.AddRelativeForce(speed * Time.fixedDeltaTime * Vector3.forward, ForceMode.VelocityChange);        
           
       }
    

    }
    private void TakingOff()
    {
        if (!isTakingOff)
        {  switch (speedController)
        {
            case <17:
                takingOffSpeed=30f;
                break;
            case >17:
                takingOffSpeed=70f;
                break;
            
        }
          playerRb.useGravity=true;
          playerRb.AddForce(takingOffSpeed * Time.fixedDeltaTime * Vector3.forward, ForceMode.VelocityChange);
          if(speedController>50f)
            {
             isTakingOff=true;
             playerRb.useGravity=false;
            }
        }
    }
    void FixedUpdate()
    {    
        TakingOff();
        RotatePlane();
        AcelerateAndBrakePlane();
        speedController=playerRb.linearVelocity.magnitude;


    }
}

