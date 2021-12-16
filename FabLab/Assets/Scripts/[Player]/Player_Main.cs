using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    #region Variables
    [Header("Player Health")]
    public float playerHealth;

    #region States
    //States That player can be in//

    //Main States of player//
    public enum MainStates {Alive, Death, InMenu};
    [Header("Player Main State")]
    public MainStates mainState;

    //Movement States of player//
    public enum MovementStates {Idle, Walk, Run};
    [Header("Player Movement States")]
    public MovementStates movementState;


    #endregion States

    #region Cases
    [Header("Player Cases")]
    public bool isMoving; //When player is changing position//
    public bool isRunning; //When player inputs run, and changing position//

    [Header("Input Cases")]
    public bool inputEnter_Movement; //If player entered movement input//
    public bool inputEnter_Look; //If player entered look input//

    #endregion Cases

    #region Possibilities
    [Header("Player Possiblities")]
    public bool canRotate = true; //If player can rotate//
    public bool canWalk = true; //If player can walk //
    public bool canRun = true;  //If player can run//

    #endregion Possibilities

    #endregion Variables



}
