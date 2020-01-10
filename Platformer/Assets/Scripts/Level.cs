using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/New Level", order = 1)]

//A common asset to store if level is unlocked and for UI manager to update
public class Level : ScriptableObject
{
    public int levelName;
    public int isUnlocked;
    public int score;

}
