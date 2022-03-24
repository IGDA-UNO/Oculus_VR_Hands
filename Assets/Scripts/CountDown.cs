using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// by Jondrielle Wilson and Aaron Autin
public class CountDown : MonoBehaviour
{
    public float countDownTime;
    public TextMeshProUGUI countText;
    public string gameText;
    
    [HideInInspector] public float minutes;
    [HideInInspector] public float seconds;
    // Start is called before the first frame update

    public void StartTimer()
    {
        StartCoroutine(Counter());  
    }

    public IEnumerator Counter()
    {
        
        while (countDownTime > 0)
        {
            minutes = Mathf.FloorToInt(countDownTime / 60);
            seconds = Mathf.FloorToInt(countDownTime % 60);

            countText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            countDownTime -= .5f;
            //Debug.Log(countDownTime);
            yield return new WaitForSecondsRealtime(1);
        }

        countText.text = gameText;

        yield return new WaitForSecondsRealtime(1);
        countText.text = null;
    }
}
