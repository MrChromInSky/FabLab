using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Assignments
    Player_Main playerMain;

    private void Awake()
    {
        playerMain = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Main>();
    }
    #endregion Assigments

    [SerializeField] Slider Energy;


    private void Update()
    {
        UpdateSlider_Energy();
    }

    void UpdateSlider_Energy()
    {
        Energy.value = playerMain.TorchEnergy;
    }
}
