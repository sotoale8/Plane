using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Camera mainCamera;
    public Camera finalCamera;

    public GameObject space; 
    public GameObject readyToLandText; 

    public GameObject endGamePanel;
    public GameObject player;
    public GameObject fireWorks;
    public GameObject finalPosition;
    public Rigidbody playerRB;

    public float speedUp=100f;
    public float speedPlane=10f;

    public  bool landed= true;
    
    void Start()
    {
        fireWorks.SetActive(true);
       
    }

    void OnEnable()
    {
        player.GetComponent<Rigidbody>().linearVelocity=Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
        player.GetComponent<Rigidbody>().isKinematic=true;
        player.GetComponent<PlayerControllerRigidbody>().enabled=false;
        player.transform.SetPositionAndRotation(finalPosition.transform.position,finalPosition.transform.rotation);
        finalCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        readyToLandText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        space.transform.Translate(speedUp * Time.deltaTime * Vector3.up,Space.World);
        player.transform.Translate(speedPlane * Time.deltaTime * Vector3.right ,Space.World);

        if (space.transform.localPosition.y>10)
        {
            endGamePanel.SetActive(true);
        }

    }
}
