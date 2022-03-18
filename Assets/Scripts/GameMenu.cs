using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//Jondrielle Wilson
public class GameMenu : MonoBehaviour
{
    public Button yourButton;
    public Button QuitButton;

    public GameManager gameManager;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Button quitbtn = QuitButton.GetComponent<Button>();
        quitbtn.onClick.AddListener(QuitTaskOnClick);
    }


     public void TaskOnClick()
    {
        gameManager.StartGamePlay();
    }

    public void QuitTaskOnClick()
    {
        //Application.Quit();
        Debug.Log("Quit Game Clicked");
    }
}
