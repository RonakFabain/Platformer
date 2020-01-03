using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{

    [HideInInspector]
    public int noOfDeaths = 10;
    public List<Vector3> spawnPoints = new List<Vector3>();

    int currentSpawnIndex = 0;

    Level levelObject;



    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {

        foreach (Transform g in transform)
        {
            spawnPoints.Add(g.transform.position);
        }
    }

    public void NextSpawnPoint()
    {
        currentSpawnIndex++;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            EndLevel();
        }
    }

    public int SendScore()
    {
        //calculate number of deaths

        return noOfDeaths;
    }

    public void EndLevel()
    {
        int currentLevel = 0;

        UIManager.Instance.LevelSelect();
        UIManager.Instance.levelList[currentLevel++].score = noOfDeaths;
        //   sendScore(); to ui manager
        //Call LevelManager and start next level

        noOfDeaths = 0;
    }


    public Vector3 Respawn()
    {
        noOfDeaths++;
        return spawnPoints[currentSpawnIndex];

    }
}
