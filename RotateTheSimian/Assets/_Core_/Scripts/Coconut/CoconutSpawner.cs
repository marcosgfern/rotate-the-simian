using System;
using System.Collections.Generic;
using UnityEngine;

public class CoconutSpawner : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private bool spawnCoconuts = false;
    [SerializeField] private float timeBetweenCoconuts = 1;

    [Header("References")]
    [SerializeField] private List<PalmTree> palmTrees;
    [SerializeField] private CoconutPool coconutPool;

    private float coconutCooldown;

    public bool SpawnCoconuts
    {
        get => spawnCoconuts;
        set => spawnCoconuts = value;
    }

    private void Start()
    {
        coconutCooldown = 0;
    }

    private void Update()
    {
        if (spawnCoconuts)
        {
            coconutCooldown -= Time.deltaTime;

            if(coconutCooldown <= 0)
            {
                coconutCooldown = timeBetweenCoconuts;
                SpawnCoconut();
            }
        }
    }

    private void SpawnCoconut()
    {
        CoconutSide side = UnityEngine.Random.Range(0, 2).Equals(0) ?
            CoconutSide.Left : CoconutSide.Right;

        foreach(PalmTree palmTree in palmTrees)
        {
            CoconutBehaviour coconut = coconutPool.GetCoconut();
            coconut.gameObject.SetActive(true);
            coconut.ResetCoconut(side);

            coconut.transform.position = palmTree.GetSpawnPosition(side);
        }
    }
    

}
