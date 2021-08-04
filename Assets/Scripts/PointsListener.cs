using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsListener : MonoBehaviour
{
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        EventBroadcaster.Instance.AddObserver(GraphGameEventNames.POINT_COLLECTED, this.addPoint);
    }

    void addPoint()
    {
        points++;
        this.GetComponent<TextMeshProUGUI>().text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       // for testing point listener
       //EventBroadcaster.Instance.PostEvent(GraphGameEventNames.POINT_COLLECTED);
    }
}
