using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public List<Vector3> spawnPoints = new List<Vector3>();
    int currentIndex = 0;

    void Start()
    {
        foreach (Transform g in transform)
        {
            spawnPoints.Add(g.transform.position);
        }

    }
    public void NextSpawnPoint()
    {
        currentIndex++;
    }

    public void EndLevel()
    {
        //Call LevelManager and start next level
        //Enable next buttons
        //Give score
        //Update UI
    }


    public Vector3 Respawn()
    {
        return spawnPoints[currentIndex];
    }
}
