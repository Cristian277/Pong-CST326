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
    public GameObject SuddenDeathText;

    public int Player1Score;
    public int Player2Score;

    public void Player1Scored()
    {
            Player1Score++;
            Player1Text.GetComponent<TextMeshProUGUI>().text = "P1 Score: " + Player1Score.ToString();
            ball.gameObject.GetComponent<Ball>().player1Bool = true;
            ResetPosition();
            ball.gameObject.GetComponent<Ball>().player1Bool = false;

            if (Player1Score == 4)
            {
                player1Paddle.GetComponent<Paddle>().sizeIncrease();
            }

            if (Player1Score >= 4 && Player1Score < 6)
            {
                Player1Text.GetComponent<TextMeshProUGUI>().color = Color.cyan;

            }
            else if (Player1Score >= 6 && Player1Score < 9)
            {
                Player1Text.GetComponent<TextMeshProUGUI>().color = Color.yellow;
            }
            else if (Player1Score >= 9 && Player1Score < 11)
            {
                Player1Text.GetComponent<TextMeshProUGUI>().color = Color.green;
            }
            else if (Player1Score == 11)
            {
                Player1Text.GetComponent<TextMeshProUGUI>().color = Color.red;
            }

            if (Player1Score == 5)
            {
                GameOver();
            }
            else if (Player1Score == 4 && Player2Score == 4)
            {
                SuddenDeathText.GetComponent<TextMeshProUGUI>().text = "SUDDEN DEATH";
                //SuddenDeathText.GetComponent<TextMeshProUGUI>().color = Color.red;
                SpeedUpGame();
            }
    }

    public void SpeedUpGame()
    {
        Time.timeScale += 1.0f;
    }

    public void Player2Scored()
    {
            Player2Score++;
            Player2Text.GetComponent<TextMeshProUGUI>().text = "P2 Score: " + Player2Score.ToString();
            ball.gameObject.GetComponent<Ball>().player2Bool = true;
            ResetPosition();
            ball.gameObject.GetComponent<Ball>().player2Bool = false;

            if (Player2Score == 4)
            {
                player2Paddle.GetComponent<Paddle>().sizeIncrease();
            }

            if (Player2Score >= 4 && Player2Score < 6)
            {
                Player2Text.GetComponent<TextMeshProUGUI>().color = Color.cyan;
            }
            else if (Player2Score >= 6 && Player2Score < 9)
            {
                Player2Text.GetComponent<TextMeshProUGUI>().color = Color.yellow;
            }
            else if (Player2Score >= 9 && Player2Score < 11)
            {
                Player2Text.GetComponent<TextMeshProUGUI>().color = Color.green;
            }
            else if (Player2Score == 11)
            {
                Player2Text.GetComponent<TextMeshProUGUI>().color = Color.red;
            }


            if (Player2Score == 5)
            {
                GameOver();

            }else if (Player1Score == 4 && Player2Score == 4)
            {
                SuddenDeathText.GetComponent<TextMeshProUGUI>().text = "SUDDEN DEATH";
                //SuddenDeathText.GetComponent<TextMeshProUGUI>().color = Color.red;
                SpeedUpGame();
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
            Debug.Log("GAME OVER Player 1 Wins! Final Score: " + Player1Score + " - " + Player2Score);
            Player1Score = 0;
            Player2Score = 0;
            Player1Text.GetComponent<TextMeshProUGUI>().text = "P1 Score: " + Player1Score.ToString();
            Player2Text.GetComponent<TextMeshProUGUI>().text = "P2 Score: " + Player2Score.ToString();
            Player1Text.GetComponent<TextMeshProUGUI>().color = Color.white;
            Player2Text.GetComponent<TextMeshProUGUI>().color = Color.white;
            SuddenDeathText.GetComponent<TextMeshProUGUI>().text = "";
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("GAME OVER Player 2 Wins! Final Score: " + Player1Score + " - " + Player2Score);
            Player1Score = 0;
            Player2Score = 0;
            Player1Text.GetComponent<TextMeshProUGUI>().text = "P1 Score: " + Player1Score.ToString();
            Player2Text.GetComponent<TextMeshProUGUI>().text = "P2 Score: " + Player2Score.ToString();
            Player1Text.GetComponent<TextMeshProUGUI>().color = Color.white;
            Player2Text.GetComponent<TextMeshProUGUI>().color = Color.white;
            SuddenDeathText.GetComponent<TextMeshProUGUI>().text = "";
            Time.timeScale = 1f;
        }

    }
}
