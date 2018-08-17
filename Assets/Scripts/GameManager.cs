using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // VARIABLES
    public bool playGame = false;
    public bool endGame = false;

    private static GameManager gameManager;
    private static GameManager instance
    {
        get
        {
            if (!gameManager)
            {
                gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (!gameManager)
                {
                    Debug.LogError("There is no active GameManager");
                }
                else
                {
                    gameManager.Init();
                }
            }

            return instance;
        }
    }

    private void Init()
    {
        if(instance == null)
        {
            //TODO Not sure if anything needs to be set here yet
        }
    }

    private void Start()
    {
        StartCoroutine("GameLoop");
    }
    

    IEnumerator GameLoop()
    {
        yield return StartCoroutine("StartGame");
        yield return StartCoroutine("PlayGame");
        yield return StartCoroutine("EndGame");
    }

    IEnumerator StartGame()
    {
        Debug.Log("Start Game");

        //Anything StartGame related

        while (!playGame)
        {
            yield return null;
        }
    }

    IEnumerator PlayGame()
    {
        Debug.Log("Play Game");

        //TODO MidGame stuff

        while (!endGame)
        {
            yield return null;
        }
    }

    IEnumerator EndGame()
    {
        Debug.Log("End Game");

        //TODO EndGame stuff

        yield return null;
    }
}
