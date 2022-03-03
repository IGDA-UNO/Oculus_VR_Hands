using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// by Jondrielle Wilson and Aaron Autin
public class CountDown : MonoBehaviour
{
    public int countDownTime;
    public TextMeshProUGUI countText;
    public string gameText;

    public float minutes;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Counter());
    }

    IEnumerator Counter()
    {
        

        while (countDownTime > 0)
        {
            minutes = Mathf.FloorToInt(countDownTime / 60);
            seconds = Mathf.FloorToInt(countDownTime % 60);

            countText.text = $"{minutes}:{seconds}";
            countDownTime--;
            //Debug.Log(countDownTime);
            yield return new WaitForSecondsRealtime(1);
        }

        countText.text = gameText;

        yield return new WaitForSecondsRealtime(1);
        countText.text = null;
    }
}
