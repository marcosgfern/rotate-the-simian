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
                SpawnCoconuts();
            }
        }
    }

    public void SpawnCoconuts()
    {
        CoconutSide side = UnityEngine.Random.Range(0, 2).Equals(0) ?
            CoconutSide.Left : CoconutSide.Right;

        foreach(PalmTree palmTree in palmTrees)
        {
            CoconutBehaviour coconut = coconutPool.GetCoconut();
            coconut.gameObject.SetActive(true);
            coconut.Fall = true;

            coconut.transform.position = palmTree.GetSpawnPosition(side);
        }
    }
    

}
