using UnityEngine.InputSystem;
using UnityEngine;

public class Player_Rotation : MonoBehaviour
{
    #region Assigments
    GameControls gameControls; //Input Action//
    Player_Main playerMain; //Player main controler//

    void Awake()
    {
        gameControls = new GameControls(); //Assign controls//
        playerMain = GetComponent<Player_Main>(); //Assign player main controller//

        mainCamera = Camera.main; //Assign main camera as main camera in script//
    }
    #endregion Assigments

    #region Variables
    [Header("Rotation Parameters")]
    [SerializeField] float rotation_SmootTime; //Time between new position and old//

    [Header("Pointer Position input")]
    [SerializeField] Vector2 lookInput; //Actual position of the mouse//
    [SerializeField] Vector3 pointerPosition; //Mouse position from camera view//

    [Header("Rotation Values")]
    float rotationValue_Calculation; //Value for smooth damp function//
    float rotationValue_Target; //Targeted Rotation//


    [Header("Camera object")]
    [SerializeField] Camera mainCamera;
    #endregion Variables

    private void Update()
    {
        if (playerMain.mainState == Player_Main.MainStates.Alive && playerMain.canRotate)
        {
            InputUpdate();
            Rotation();
        }
        else
        {
            Debug.Log("Oh no no no no, no rotation for U silly");
        }

    }



    void InputUpdate()
    {
        //Updates position of mouse and poniter in camera space//
        lookInput = gameControls.Player.Look.ReadValue<Vector2>();
        pointerPosition = mainCamera.ScreenToWorldPoint(lookInput);
    }

    void Rotation()
    {
        Vector3 diff = pointerPosition - transform.position;
        diff.Normalize();

        rotationValue_Target = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, Mathf.SmoothDamp(transform.rotation.z, rotationValue_Target, ref rotationValue_Calculation, rotation_SmootTime));

        transform.rotation = Quaternion.Euler(0, 0, rotationValue_Target);


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
