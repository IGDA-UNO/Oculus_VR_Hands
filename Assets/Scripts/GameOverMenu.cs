using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Jondrielle Wilson
public class GameOverMenu : MonoBehaviour
{
    public Button playAgainButton;
    public Button QuitButton;
    public GameObject menuOffset;
   

    void Start()
    {
        Button btn = playAgainButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Button quitbtn = QuitButton.GetComponent<Button>();
        quitbtn.onClick.AddListener(QuitTaskOnClick);
    }

    private void Update()
    {
      
        transform.position = menuOffset.transform.position;
       
    }

    public void TaskOnClick()
    {
        SceneManager.LoadScene("RLGL_Arena");
        
    }

    public void QuitTaskOnClick()
    {
        Application.Quit();
    }
}
