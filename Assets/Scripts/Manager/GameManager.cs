using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [Header("Scripts")] 
    public UIController uiController;
    public ObjectPool objectPool = null;
    public MoneyObjectPool moneyObjectPool;
    public TreeController treeController;
    public AppleController appleController;
    public StackManager stackManager;
    public StoreManager storeManager;
    public PlayerController playerController;

    
    public GameState gameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        GameStateChanged();
    }

    public void ChangeGameState(GameState newGameState)
    {
        gameState = newGameState;
        GameStateChanged();
    }

    public void GameStateChanged()
    {
        if (gameState == GameState.Start)
        {
             uiController.startBtn.SetActive(false);
        }
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameStart()
    {
        gameState = GameState.Start;
        
    }

    public enum GameState
    {
        Start,
        Finish,
        None
        
    }
}