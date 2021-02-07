using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (isPlayer1Goal)
            {
                Debug.Log("Player 2 Scored");
                GameObject.Find("Manager").GetComponent<Manager>().Player2Scored();
            }
            else
            {
                Debug.Log("Player 1 Scored");
                GameObject.Find("Manager").GetComponent<Manager>().Player1Scored();
            }

        }
    }
}
