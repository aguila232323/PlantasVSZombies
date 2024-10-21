using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject Zombie;
    [SerializeField] private Transform[] SpawnsPoints;
    [SerializeField] ZombieTypeProb[] zombiesTypes;

    private List<ZombiesTypes> probList = new List<ZombiesTypes>();

    [SerializeField] private int MaxZombiesNum;
    [SerializeField] private int ZombiesSpawned;
    [SerializeField] private Slider progress;
    [SerializeField] private float zombieDealy = 5;

    private void Start()
    {

        InvokeRepeating("SpawnZombie",15,zombieDealy);
        foreach (ZombieTypeProb i in zombiesTypes)
        {
            for (int j = 0; j < i.probability; j++)
            {
                probList.Add(i.type);
            }

        }
        progress.maxValue = MaxZombiesNum;
    }

    private void Update()
    {
        progress.value = ZombiesSpawned;
    }

    void SpawnZombie()
    {
        if (ZombiesSpawned>=MaxZombiesNum)
        {
            return;
        }
        ZombiesSpawned++;
        int NumSpawner = Random.Range(0, SpawnsPoints.Length);
        GameObject NewZombie = Instantiate(Zombie, SpawnsPoints[NumSpawner].position, Quaternion.identity);
        NewZombie.GetComponent<ZombieMovement>().setTipe(probList[Random.Range(0, probList.Count)]);
        if (ZombiesSpawned >= MaxZombiesNum)
        {
            NewZombie.GetComponent<ZombieMovement>().setLast(true);
        }



    }
}
[System.Serializable]
public class ZombieTypeProb
{
    public ZombiesTypes type;
    public int probability;
}