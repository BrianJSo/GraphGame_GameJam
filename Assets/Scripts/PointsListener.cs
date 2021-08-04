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
        PlayerPrefs.SetInt(GraphGameEventNames.PREF_POINTS, points);
        EventBroadcaster.Instance.AddObserver(GraphGameEventNames.POINT_COLLECTED, this.addPoint);
        EventBroadcaster.Instance.AddObserver(GraphGameEventNames.TIME_UP, this.savePoints);
    }

    void savePoints()
    {
        PlayerPrefs.SetInt(GraphGameEventNames.PREF_POINTS, points);
    }

    void addPoint()
    {
        points++;
        this.GetComponent<TextMeshProUGUI>().text = points.ToString();
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GraphGameEventNames.POINT_COLLECTED);
        EventBroadcaster.Instance.RemoveObserver(GraphGameEventNames.TIME_UP);

    }


    // Update is called once per frame
    void Update()
    {
       // for testing point listener
       //EventBroadcaster.Instance.PostEvent(GraphGameEventNames.POINT_COLLECTED);
    }
}
