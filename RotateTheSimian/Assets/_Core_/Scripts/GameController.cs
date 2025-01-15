using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private List<SimianBehaviour> simians;
    [SerializeField] private CoconutSpawner coconutSpawner;
    [SerializeField] private CountdownController countdownController;


    void Start()
    {
        countdownController.CountdownEnded += StartGame;

        foreach (SimianBehaviour simian in simians)
        {
            simian.Move = false;
        }
        coconutSpawner.SpawnCoconuts = false;

        countdownController.StartCountdown();
    }



    public void StartGame()
    {
        foreach (SimianBehaviour simian in simians)
        {
            simian.Move = true;
        }
        coconutSpawner.SpawnCoconuts = true;
    }
}
