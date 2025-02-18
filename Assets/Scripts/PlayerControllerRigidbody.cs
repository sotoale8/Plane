using System;
using Unity.Mathematics;
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
    public float landingSpeed=20;
    public float speedController;
    public  float  horizontal;
    public  float  vertical;

    public float rotationxForce;
    public float rotationyForce;
    public float rotationzForce;
    public float rotationGroundForce;

    public bool isTakingOff;
    public bool isZLevelOk; 
    public float zLevel; 
    public bool isLanding=false; 

    public Transform groundCheck;
    private Vector3 groundCheckSize= new(1f,1f,1f);
    public LayerMask roadMask;

    public bool isGround;
    
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
        CheckOrientation();
        CheckLanding();
        isGround = Physics.CheckBox(groundCheck.position,groundCheckSize,groundCheck.rotation,roadMask);
      

    }

    private void CheckLanding()
    {
        if (isZLevelOk && speedController<30 && isTakingOff && isGround)
            {
                isLanding=true;
            }
        else
            {
                isLanding=false;    
            }

    }

    private void CheckOrientation()
    {
         zLevel=transform.rotation.eulerAngles.z; 
        
        zLevel = zLevel > 180 ? zLevel-360 :zLevel; //normalizacion de la rotacion del avion

        if (zLevel >= -10f && zLevel <= 10f)
            {
                isZLevelOk=true;
            }
        else
            {
                isZLevelOk=false;
            }
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
            if (isTakingOff)
            {
                playerRb.AddRelativeTorque(horizontal*Time.fixedDeltaTime*rotationyForce*Vector3.up,ForceMode.Force);
                playerRb.AddRelativeTorque(vertical*Time.fixedDeltaTime*rotationxForce*Vector3.right,ForceMode.Force); 
            }
       if (Input.GetKey(KeyCode.E) && isTakingOff )
            {
                playerRb.AddRelativeTorque(Time.fixedDeltaTime*rotationzForce*-Vector3.forward,ForceMode.Force);
            }
       
       if (Input.GetKey(KeyCode.Q) && isTakingOff)
            {
                playerRb.AddRelativeTorque(Time.fixedDeltaTime*rotationzForce*Vector3.forward,ForceMode.Force);  
            }

        }
    private void AcelerateAndBrakePlane()
    {
        if (Input.GetKey(KeyCode.C) && isTakingOff && !isLanding)
            {   
                 playerRb.AddRelativeForce(breakSpeed * Time.fixedDeltaTime * Vector3.forward, ForceMode.VelocityChange);            
            }
       else if (isTakingOff && !isLanding)
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
    
    private void Landing()
    {   
        playerRb.useGravity=true;
        playerRb.AddRelativeForce(landingSpeed * Time.fixedDeltaTime * Vector3.forward, ForceMode.VelocityChange);    
        playerRb.AddRelativeTorque(horizontal*Time.fixedDeltaTime*rotationGroundForce*Vector3.up,ForceMode.Force);
           
    }
    
    void FixedUpdate()
    {    
        TakingOff();
        RotatePlane();
        AcelerateAndBrakePlane();
        speedController=playerRb.linearVelocity.magnitude;
        if (isLanding)
        {
           Landing();
        }

    }

}

