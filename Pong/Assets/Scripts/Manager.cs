using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player 2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("Score UI")]
    public GameObject Player1Text;
    public GameObject Player2Text;
    public GameObject GameOverText;

    public int Player1Score;
    public int Player2Score;

    public void Player1Scored()
    {
            Player1Score++;
            Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
            ball.gameObject.GetComponent<Ball>().player1Bool = true;
            ResetPosition();
            ball.gameObject.GetComponent<Ball>().player1Bool = false;

        if (Player1Score == 5)
            {
                //Time.timeScale = 0;
                GameOver();
            }
    }

    public void Player2Scored()
    {
            Player2Score++;
            Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
            ball.gameObject.GetComponent<Ball>().player2Bool = true;
            ResetPosition();
            ball.gameObject.GetComponent<Ball>().player2Bool = false;

            if (Player2Score == 5)
            {
                //Time.timeScale = 0;
                GameOver();
            }
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }

    private void GameOver()
    {
        if (Player1Score > Player2Score)
        {
            Debug.Log("GAME OVER Player 1 Wins! Final Score: " + Player1Score + " to " + Player2Score);
            Player1Score = 0;
            Player2Score = 0;
            Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
            Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        }
        else
        {
            Debug.Log("GAME OVER Player 2 Wins! Final Score: " + Player1Score + " to " + Player2Score);
            Player1Score = 0;
            Player2Score = 0;
            Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
            Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        }
        
    }
}
