using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// Ben Samuel, Norman Bennett
public class GameManager : MonoBehaviour
{

    // enumerated values
    public enum State { PREGAME, GAMEPLAY, POSTGAME };

    // exposed variables
    public bool isGreenLight;
    public float minLightTimer = 0.5f;
    public float maxLightTimer = 2.0f;
    public float currentTimeLeft;
    public Material redLight;
    public Material greenLight;
    public TextMeshProUGUI countDownText;

    // hidden variables
    //[HideInInspector] public CountDown timer;
    [HideInInspector] public State currentState;

    
    //public Material blueSky;
    //public GameObject dead;

    //MeshRenderer lightRenderer;




    public Player player;

    string currentLight;

    // Start is called before the first frame update
    void Start()
    {
        player = (Player) Object.FindObjectOfType(typeof(Player));
        countDownText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        InitializeGame();
        //Debug.Log("Starting time in red light land: " + currentTimeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) 
        {

            case State.PREGAME:
                break;
            case State.POSTGAME:
                break;
            case State.GAMEPLAY:
                player.UpdatePlayer();
                UpdateGameState();
                break;
        }


        
        
    }

    void UpdateGameState()
    {
        currentTimeLeft -= Time.deltaTime;
        //Debug.Log("remaining time: " + currentTimeLeft);

        //It is time to switch the light!
        if (currentTimeLeft <= 0)
        {
            //change text
            switchLightName();

            //print out that it has changed states
            //Debug.Log(currentLight + " Light!");

            //get a new random interval
            currentTimeLeft = getTimeInRange();

            //flip the boolean!
            isGreenLight = !isGreenLight;

            //Change which light bulb image we're using.
            if (isGreenLight)
            {
                RenderSettings.skybox = greenLight;
                countDownText.color = new Color(.0f, 1.0f, .0f, 1.0f);
            }
            else
            {
                RenderSettings.skybox = redLight;
                countDownText.color = new Color(1.0f, .0f, .0f, 1.0f);
            }

        }


        if (!isGreenLight)
        {
            if (player.getIsMoving())
            {
              //kill the player!
              //dead.SetActive(true);
                Debug.Log("GOT YOU! PLAYER DIED!");
                //player.killOff();
                //player.rb.freezeRotation = false;
                //player.transform.gameObject.SetActive(false);
                //player.gameObject.SetActive(false);
                //Destroy(player.transform.gameObject);
            }
        }
    }

    float getTimeInRange(){
        return Random.Range(minLightTimer, maxLightTimer);
    }

    void switchLightName(){
            if(isGreenLight){
                //switching from green to red
                currentLight = "red";
            }
            else{
                currentLight = "green";
            }
    }

    void InitializeGame()
    {
        currentState = State.PREGAME;
        isGreenLight = false;
        currentLight = "red";
        currentTimeLeft = getTimeInRange();
    }

    public void StartGamePlay()
    {
        //timer.StartTimer();
        currentState = State.GAMEPLAY;
    }


}
