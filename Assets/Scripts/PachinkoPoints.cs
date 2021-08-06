using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PachinkoPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI curPointsText;
    [SerializeField] private TextMeshProUGUI multiplierText;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private int curPoints;
    private int multiplier;
    private int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        curPoints = PlayerPrefs.GetInt(GraphGameEventNames.PREF_POINTS);
        curPointsText.text = curPoints.ToString();

        EventBroadcaster.Instance.AddObserver(GraphGameEventNames.PACHINKO_DONE, this.computeScore);
    }

    void computeScore(Parameters parameters)
    {   
        multiplier = parameters.GetIntExtra(GraphGameEventNames.PACHINKO_MULTIPLIER, 1);
        finalScore = multiplier * curPoints;
        multiplierText.text = multiplier.ToString();
        finalScoreText.text = " = " + finalScore.ToString();
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GraphGameEventNames.PACHINKO_DONE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
