using UnityEngine;

public class LigthFollow : MonoBehaviour
{   
    GameObject player;
    public float rangeFollow;
    public float distanceMagnitud;
    private Light lightFollow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Plane");
        lightFollow= GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 distance = player.transform.position - transform.position;
        if (rangeFollow> distance.magnitude)
            {   
                lightFollow.enabled=true;
                transform.LookAt(player.transform);
            }
            else
            {
             lightFollow.enabled=false;
            }
    }
}
