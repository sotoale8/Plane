using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MissileBehaviour : MonoBehaviour
{
    Rigidbody rbMissile;
    public AudioClip audioClip;
    AudioSource audioSource;
    public float speedMissile;
   
    ParticleSystem smokePrefab;
    public Transform spawnSmoke;
    
    public Transform positionTank;

    void Start()
    {   
        smokePrefab = GetComponentInChildren<ParticleSystem>();
        rbMissile= GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
        smokePrefab.Play();
        transform.LookAt(positionTank);
        

    }

    void FixedUpdate()
    {
        rbMissile.AddRelativeForce(Vector3.forward*Time.fixedDeltaTime*speedMissile,ForceMode.VelocityChange); 
        Destroy(this.gameObject,5f);

    }
}
