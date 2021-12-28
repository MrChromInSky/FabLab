using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public int endingScenenuber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player_Main>().haveAKey)
            {
                SceneManager.LoadScene(endingScenenuber, LoadSceneMode.Single);
            }
            else
            {

            }
        }
    }
}
