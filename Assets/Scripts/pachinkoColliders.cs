using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pachinkoColliders : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int multiplier = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        Parameters param = new Parameters();
        param.PutExtra(GraphGameEventNames.PACHINKO_MULTIPLIER, multiplier);
        EventBroadcaster.Instance.PostEvent(GraphGameEventNames.PACHINKO_DONE, param);
    }
}
