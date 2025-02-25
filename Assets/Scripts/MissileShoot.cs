using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissileShoot : MonoBehaviour
{
    public Rigidbody missilePrefab;
    public Vector3 planeVelocity;
    public Rigidbody planeRB;

    public float fireRate;
    public float contS;

    public float timerLock;
    public LayerMask layerMask;

    public PlayerInteractions playerInteractions;

    public Slider slider;

    private Coroutine coroutine;

    public bool tankAdquired;
    public static Transform positionTank;

    public TextMeshProUGUI tankLockedText;

    public Light lightShoot;

    public float contColor;

    public AudioClip audioLocked;

    private Coroutine ctine;

    void Start()
    {
        
        planeVelocity = planeRB.linearVelocity;
        playerInteractions = FindAnyObjectByType<PlayerInteractions>();   
        lightShoot= GetComponentInChildren<Light>();
      
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

        if (playerInteractions.powerUpCollected && Physics.SphereCast(transform.position+Vector3.up*2f , 2f, transform.forward, out RaycastHit hit, 500,layerMask))
        {
           
                lightShoot.enabled=true;
                positionTank = hit.collider.transform;
                timerLock+=Time.deltaTime;
                slider.value=timerLock;
                tankAdquired = timerLock >= 0.5;
                contColor+=Time.deltaTime;
               
                
        

        }
            else
            {   
                lightShoot.enabled=false;
                tankAdquired=false;
                timerLock=0f;
                slider.value=0f;
                tankLockedText.color= Color.white;
                contColor=0f;
            
            }

       if(tankAdquired && contColor>0.15)
            {  
           
             tankLockedText.color= (tankLockedText.color==Color.white) ? Color.red : Color.white;
             contColor=0f;
             AudioManager.Instance.PlaySFX(audioLocked);
            }
      

    }

  
}
