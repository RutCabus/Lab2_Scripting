using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    
    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();

    public float timeBetweenSpawns;

    //Variables de dificultat per a anar reduint timeBetweenSpawns
    public float minSpawnTime = 0.5f;
    public float decreaseAmount = 0.1f;
    public float difficultyInterval = 10f;

    private List<GameObject> sheepList = new List<GameObject>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(DifficultyRoutine()); //Arrencar nova corutina
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; 
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); 
        sheepList.Add(sheep); 
        sheep.GetComponent<Sheep>().SetSpawner(this);
    }
    private IEnumerator SpawnRoutine() 
    {
        while (canSpawn) 
        {
            SpawnSheep(); 
            yield return new WaitForSeconds(timeBetweenSpawns); 
        }
    }
    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }
    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList) 
        {
            Destroy(sheep); 
        }

        sheepList.Clear();
    }

    //Corutina de dificultat
    private IEnumerator DifficultyRoutine()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(difficultyInterval);

            if (timeBetweenSpawns > minSpawnTime)
            {
                timeBetweenSpawns -= decreaseAmount;
                Debug.Log("Nova velocitat spawn: " + timeBetweenSpawns);
            }
        }
    }

}
