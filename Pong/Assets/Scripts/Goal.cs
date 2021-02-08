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
                GameObject.Find("Manager").GetComponent<Manager>().Player2Scored();
                Debug.Log("Player 2 Scored!" + "\n" + "Current Score: " + GameObject.Find("Manager").GetComponent<Manager>().Player1Score + " - " + GameObject.Find("Manager").GetComponent<Manager>().Player2Score);
               
            }
            else
            {
                GameObject.Find("Manager").GetComponent<Manager>().Player1Scored();
                Debug.Log("Player 1 Scored!" + "\n" + "Current Score: " + GameObject.Find("Manager").GetComponent<Manager>().Player1Score + " - " + GameObject.Find("Manager").GetComponent<Manager>().Player2Score);
                
            }

        }
    }
}
