using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//CheckPoint
[AddComponentMenu("FirstPerson/Checkpoint")]
public class CheckPoint : MonoBehaviour 
{
    #region Variables
    [Header("Check Point Elements")]
    public GameObject currentCheckPoint;
    [Header("Character Handler")]
    public CharacterHandler charH;
    #endregion
    #region Start

    #region Check if we have Key
    private void Start()
    {    //the character handler is the component attached to our player
        charH = GetComponent<CharacterHandler>();
        //if we have a save key called SpawnPoint
        if (PlayerPrefs.HasKey("SpawnPoint"))
        {
            //then our checkpoint is equal to the game object that is named after our save file
            currentCheckPoint = GameObject.Find(PlayerPrefs.GetString("SpawnPoint"));
            //our transform.position is equal to that of the checkpoint
            transform.position = currentCheckPoint.transform.position;
        }
    }
    #endregion
    #endregion
    #region Update
    private void Update()
    {
        //if our characters health is less than or equal to 0
        if (charH.curHealth == 0 )

        {
            //our transform.position is equal to that of the checkpoint
            transform.position = currentCheckPoint.transform.position;
            //our characters health is equal to full health
            charH.curHealth = charH.maxHealth;
            //character is alive
            charH.alive = true;
            //character's controller is active		
            charH.controller.enabled = true;
        }

    }
    #endregion
    #region OnTriggerEnter
    //Collider other
    private void OnTriggerEnter(Collider other)
    {
        //if our other objects tag when compared is CheckPoint
        if (other.gameObject.tag == "CheckPoint")
        {
            //our checkpoint is equal to the other object
            currentCheckPoint = other.gameObject;
            //save our SpawnPoint as the name of that object
            PlayerPrefs.SetString("SpawnPoint", currentCheckPoint.name);
        }
    }

    #endregion
}





