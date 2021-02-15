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
            ball.gameObject.GetComponent<Ball>().scoreSound();
            Player1Text.GetComponent<TextMeshProUGUI>().text = "P1 Score: " + Player1Score.ToString();
            ball.gameObject.GetComponent<Ball>().player1Bool = true;
            ResetPosition();
            ball.gameObject.GetComponent<Ball>().player1Bool = false;

            if (Player1Score == 2)
            {
                player1Paddle.GetComponent<Paddle>().sizeIncrease();
                Debug.Log("P1 Paddle size increased");
                Player1Text.GetComponent<TextMeshProUGUI>().color = Color.cyan;
            }

            if (Player1Score == 3)
            {
                Player1Text.GetComponent<TextMeshProUGUI>().color = Color.yellow;
            }
            else if (Player1Score == 4)
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
                SpeedUpGame();
            }
    }

    public void SpeedUpGame()
    {
        Time.timeScale += 0.8f;
    }

    public void Player2Scored()
    {
            Player2Score++;
            ball.gameObject.GetComponent<Ball>().scoreSound();
            Player2Text.GetComponent<TextMeshProUGUI>().text = "P2 Score: " + Player2Score.ToString();
            ball.gameObject.GetComponent<Ball>().player2Bool = true;
            ResetPosition();
            ball.gameObject.GetComponent<Ball>().player2Bool = false;

            if (Player2Score == 2)
            {
                player2Paddle.GetComponent<Paddle>().sizeIncrease();
                Debug.Log("P2 Paddle size increased");
                Player2Text.GetComponent<TextMeshProUGUI>().color = Color.cyan;
            }

            if (Player2Score == 3)
            {
                Player2Text.GetComponent<TextMeshProUGUI>().color = Color.yellow;
            }
            else if (Player2Score == 4)
            {
                Player2Text.GetComponent<TextMeshProUGUI>().color = Color.red;
            }

            if (Player2Score == 5)
            {
                GameOver();
            }
            else if (Player1Score == 4 && Player2Score == 4)
            {
                SuddenDeathText.GetComponent<TextMeshProUGUI>().text = "SUDDEN DEATH";
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
            PauseGame();
            ball.GetComponent<Ball>().gameOver = true;
            ResetPosition();
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
            PauseGame();
            ball.GetComponent<Ball>().gameOver = true;
            ResetPosition();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        ball.GetComponent<Ball>().gameOver = false;
        Time.timeScale = 1f;
        
    }
}
