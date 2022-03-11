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

    void Start()
    {
        Button btn = playAgainButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Button quitbtn = QuitButton.GetComponent<Button>();
        quitbtn.onClick.AddListener(QuitTaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Main");
    }

    void QuitTaskOnClick()
    {
        Application.Quit();
    }
}
