using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script can be found in the Component section under the option NPC/Dialogue
[AddComponentMenu("FirstPerson")]
public class Dialogue : MonoBehaviour
{
    #region Variables
    [Header("References")]
    //boolean to toggle if we can see a characters dialogue box
    public bool showDialogue;
    //index for our current line of dialogu and an index for a set question marker of the dialogue 
    public int currentLine;
    public int optionIndex;

    //object reference to the player movement 
    public CharacterMovement playerMovement;

    //mouselook script reference for the player
    public MouseLook characterLook;

    [Header("NPC Name and Dialogue")]
    //name of this specific NPC
    public string NPCName;
    //array for text for our dialogue
    public string[] text;
    [Header("ScreenRatio")]
    //Screen x and y
    public Vector2 scr;
    #endregion
    #region Start
    private void Start()
    {
        //find and reference the player object by tag,get movement
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        //find and reference the maincamera by tag and get the mouse look component 
        characterLook = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
    }

    #endregion
    #region OnGUI 
    private void OnGUI()
    {
        //if our dialogue can be seen on screen
        if (showDialogue)
        {
            //set up our ratio messurements for 16:9
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
            //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPC's name and current dialogue line
            GUI.Box(new Rect(0, 6 * scr.y, Screen.width, 3 * scr.y), NPCName + " " + text[currentLine]);
            //if not at the end of the dialogue or not at the options part
            if (!(currentLine >= text.Length - 1 || currentLine == optionIndex))
            {
                //next button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Next"))
                {
                    //move forward in our dialogue array
                    currentLine++;
                }

            }

            //else if we are at options
            else if (currentLine == optionIndex)
            {
                //Accept button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(13 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Accept"))
                {
                    currentLine++;
                }

                //Decline button skips us to the end of the characters dialogue 
                if (GUI.Button(new Rect(14 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Decline"))
                {
                    //skip to the end of dialogue;
                    currentLine = text.Length - 1;
                }
            }
            //else we are at the end
            else
            {

                //the Bye button allows up to end our dialogue
                if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Run away"))
                {
                    //close the dialogue box
                    showDialogue = false;

                    //set index back to 0 
                    currentLine = 0;

                    //allow camera's mouselook to be turned back on
                    characterLook.enabled = true;

                    //get the component movement on the character and turn that back on
                    playerMovement.enabled = true;
                    //lock the mouse cursor
                    Cursor.lockState = CursorLockMode.Locked;
                    //set the cursor to being invisible
                    Cursor.visible = false;
                }
            }
        }
    }

    #endregion
}
