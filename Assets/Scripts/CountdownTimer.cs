using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float startingTime = 10f;
    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] private GameObject pachinkoTimePanel;
    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        string minutes = (Mathf.Floor(currentTime / 60)).ToString("00");
        string seconds = (Mathf.Floor(currentTime % 60)).ToString("00");
        countDownText.text = minutes + ":" + seconds;

        if(currentTime <= 0)
        {
            pachinkoTimePanel.SetActive(true);
            EventBroadcaster.Instance.PostEvent(GraphGameEventNames.TIME_UP);
        }

        if (currentTime <= -2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Pachinko");
        }
    }
}
