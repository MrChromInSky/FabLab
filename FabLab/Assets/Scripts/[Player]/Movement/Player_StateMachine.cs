using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StateMachine : MonoBehaviour
{
    Player_Main playerMain; //Player main controler//

    void Awake()
    {
        playerMain = GetComponent<Player_Main>(); //Assign player main controller//
    }

    private void Update()
    {
        switch (playerMain.mainState)
        {
            case Player_Main.MainStates.Alive:
                MovementState_Controller();
                return;
        }

    }


    void MovementState_Controller()
    {

        if(playerMain.inputEnter_Movement)
        {
            if(playerMain.isRunning)
            {
                playerMain.movementState = Player_Main.MovementStates.Run;
            }
            else
            {
                playerMain.movementState = Player_Main.MovementStates.Walk;
            }
        }
        else
        {
            playerMain.movementState = Player_Main.MovementStates.Idle;
        }
    }
}
