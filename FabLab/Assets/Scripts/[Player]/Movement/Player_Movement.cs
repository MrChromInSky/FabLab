using UnityEngine.InputSystem;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    #region Assigments
    GameControls gameControls; //Input Action//
    Player_Main playerMain; //Player main controler//
    Rigidbody2D playerController; //Player rigidbody controller//

    void Awake()
    {
        gameControls = new GameControls(); //Assign controls//
        playerMain = GetComponent<Player_Main>(); //Assign player main controller//
        playerController = GetComponent<Rigidbody2D>();
    }
    #endregion Assigments

    #region Variables
    [Header("Speed Parameters")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    [Header("Stop Parameters")]
    [SerializeField] float stopSpeed;
    [SerializeField] float stopAcceleration;
    [SerializeField] Vector2 stopCalculations;

    [Header("Target Speed")]
    [SerializeField] Vector2 targetSpeed;
    [SerializeField] Vector2 finalVector;

    [Header("Input Value")]
    Vector2 movementInput;

    #endregion Variables



    void Update()
    {
        InputUpdate();
            
        switch (playerMain.mainState)
        {
            case Player_Main.MainStates.Alive:
                MovementSpeed_Controller();
                return;



        }

    }

    #region Speeds

    void MovementSpeed_Controller()
    {
        switch (playerMain.movementState)
        {
            case Player_Main.MovementStates.Idle:
                Movement_Idle();
                return;

            case Player_Main.MovementStates.Walk:
                Movement_Walk();
                return;

            case Player_Main.MovementStates.Run:
                Movement_Run();
                return;

        }
    }

    void Movement_Idle()
    {
        targetSpeed = Vector2.zero;
    }

    void Movement_Walk()
    {
        targetSpeed = new Vector2(movementInput.x * walkSpeed, movementInput.y * walkSpeed);
    }

    void Movement_Run()
    {
        targetSpeed = new Vector2(movementInput.x * walkSpeed, movementInput.y * walkSpeed);
    }

    #endregion Speeds


    void FixedUpdate()
    {
        ExecuteMovement();
    }

    void ExecuteMovement()
    {
        switch (playerMain.movementState)
        {
            case Player_Main.MovementStates.Idle:
                ExecuteMovement_Idle();
                return;

            case Player_Main.MovementStates.Walk:
                ExecuteMovement_Walk();
                return;

            case Player_Main.MovementStates.Run:
                ExecuteMovement_Run();
                return;

        }
    }

    void ExecuteMovement_Idle() //Stops//
    {
        playerController.MovePosition(playerController.position + targetSpeed * Time.fixedDeltaTime);
    }

    void ExecuteMovement_Walk()
    {
        // playerController.MovePosition(playerController.position + targetSpeed * Time.fixedDeltaTime);
        playerController.velocity = targetSpeed;
    }

    void ExecuteMovement_Run()
    {

    }

    void InputUpdate()
    {
        movementInput = gameControls.Player.Movement.ReadValue<Vector2>();

        if(movementInput != Vector2.zero)
        {
            playerMain.inputEnter_Movement = true;
        }
        else
        {
            playerMain.inputEnter_Movement = false;
        }
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





