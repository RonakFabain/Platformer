using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/New Level", order = 1)]

public class Level : ScriptableObject
{
  
    public int levelName;
    public int isUnlocked;
    public int score;

}
