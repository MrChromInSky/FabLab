using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("dupa");


        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Main>().haveAKey = true;
            Destroy(this.gameObject);
        }
    }

}
