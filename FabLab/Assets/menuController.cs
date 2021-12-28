using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuController : MonoBehaviour
{
   public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Exxxxxit()
    {
        Application.Quit();
    }
}
