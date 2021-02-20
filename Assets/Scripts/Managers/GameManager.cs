using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public int timeToEnd = 240;
    public bool gamePause = false;

    private bool endGame = false;
    private bool win = false;

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win) Debug.Log("You win!! Reload?");
        else Debug.Log("You lose!! Reload?");
    }

    private void Awake()
    {
        if(gameManager==null) gameManager = this;
    }
    public void PauseGame()
    {
        Debug.Log("Game paused");
        gamePause = true;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Debug.Log("Game resume");
        gamePause = false;
        Time.timeScale = 1f;
    }
    public void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + "s");
        if (timeToEnd <= 0f)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame) EndGame();

    }
    
    void Start()
    {
        InvokeRepeating("Stopper", 2, 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePause==true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
           

        }
    }
}
