using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool isGreenLight; 
    public float minLightTimer = 0.5f;
    public float maxLightTimer = 2.0f;
    float currentTimeLeft;

    public Material redLight;
    public Material greenLight;
    //public Material blueSky;
    //public GameObject dead;

    //MeshRenderer lightRenderer;




    public Player[] thePlayers;

    string currentLight;

    // Start is called before the first frame update
    void Start()
    {
        isGreenLight = false;
        currentLight = "red";
        currentTimeLeft = getTimeInRange();
        //dead.SetActive(false);
        //Debug.Log("Starting time in red light land: " + currentTimeLeft);
        thePlayers = (Player[]) Object.FindObjectsOfType(typeof(Player));
        //lightRenderer = GameObject.Find("Light").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLeft -= Time.deltaTime;
        //Debug.Log("remaining time: " + currentTimeLeft);

        //It is time to switch the light!
        if(currentTimeLeft <= 0){
            //change text
            switchLightName();

            //print out that it has changed states
            //Debug.Log(currentLight + " Light!");

            //get a new random interval
            currentTimeLeft = getTimeInRange();

            //flip the boolean!
            isGreenLight = !isGreenLight;

            //Change which light bulb image we're using.
            if(isGreenLight){
                RenderSettings.skybox = greenLight;
            }
            else{
                RenderSettings.skybox = redLight;
            }
            


        }


        if(!isGreenLight){
            foreach(Player player in thePlayers){
                if(player.rb.velocity.z >= 0.1f ){ // if(player.getIsMoving())
                    //kill the player!
                    //dead.SetActive(true);
                    Debug.Log("GOT YOU! PLAYER DIED!");
                    //player.killOff();
                    player.rb.freezeRotation = false;
                    //player.transform.gameObject.SetActive(false);
                    //player.gameObject.SetActive(false);
                    //Destroy(player.transform.gameObject);
                }
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



}
