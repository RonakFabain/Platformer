using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class LevelManager : MonoBehaviour
{

    [HideInInspector]
    public int noOfDeaths = 0;
    public List<Vector3> spawnPoints = new List<Vector3>();
    Level levelObject;

    private int currentSpawnIndex = 0;// Start from ZERO
    private int currentLevel = 0;
   


    void Start()
    {
        foreach (Transform g in transform)
        {
            spawnPoints.Add(g.transform.position);
        }
    }
    //Set next spawn point when collision is triggered by player
    public void NextSpawnPoint()
    {
        currentSpawnIndex++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            EndLevel();
        }
    }

    //calculate number of deaths
    public int SendScore()
    {
        return noOfDeaths;
    }


    public void EndLevel()
    {
        //Check if level is already played.Set score
        //If not played then unlock next level and update UI
        currentLevel = SceneManager.GetActiveScene().buildIndex;


        UIManager.Instance.LevelSelect();
        UIManager.Instance.levelList[currentLevel].isUnlocked = 1;

        currentLevel--;

        UIManager.Instance.levelList[currentLevel].score = noOfDeaths;
        UIManager.Instance.InitLevelUI();

        //Reset score for next level
        noOfDeaths = 0;
    }

    //Add number of deaths and set position of player to current Spawn point 
    public Vector3 Respawn()
    {
        noOfDeaths++;
        return spawnPoints[currentSpawnIndex];
    }

    void ReloadCurrentLevel()
    {
        noOfDeaths = 0;
        currentSpawnIndex = 0;
    }
}
