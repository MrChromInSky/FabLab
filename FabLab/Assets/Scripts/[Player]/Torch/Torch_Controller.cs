using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Torch_Controller : MonoBehaviour
{
    #region Assigments
    GameControls gameControls; //Input Action//
    Player_Main playerMain; //Player main controler//

    void Awake()
    {
        gameControls = new GameControls(); //Assign controls//
        playerMain = GetComponent<Player_Main>(); //Assign player main controller//

        gameControls.Player.Flashlight.performed += ctx => TorchControler();
    }

    #endregion Assigments

    #region Variables
    [SerializeField] GameObject torch;
    [SerializeField] float maxEnergy;
    public float actualEnergy;
    [SerializeField] float batteryUsagespeed;

    #endregion Variables

    private void Start()
    {
        actualEnergy = maxEnergy;
    }

    void TorchControler()
    {
        if(playerMain.canUseTorch && actualEnergy > 0)
        {
            if(torch.gameObject.activeInHierarchy)
            {
                torch.SetActive(false);
            }
            else
            {
                torch.SetActive(true);
            }
        }
        else
        {
            torch.SetActive(false);
        }


    }

    private void Update()
    {
        if (torch.gameObject.activeInHierarchy)
        {
            if(actualEnergy > 0)
            {
                actualEnergy -= batteryUsagespeed * Time.deltaTime;
            }
            else
            {
                actualEnergy = 0;
            }
           
        }

        if(actualEnergy == 0)
        {
            torch.SetActive(false);
        }

        playerMain.TorchEnergy = actualEnergy;
    }

    #region OnEnable, OnDisable
    void OnEnable()
    {
        gameControls.Enable();
    }

    void OnDisable()
    {
        gameControls.Disable();
    }

    #endregion OnEnable, OnDisable
}

