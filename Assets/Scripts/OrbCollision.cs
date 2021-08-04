using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EventBroadcaster.Instance.PostEvent(GraphGameEventNames.POINT_COLLECTED);
            print(GraphGameEventNames.POINT_COLLECTED);
            Destroy(gameObject);
        }
    }
}
