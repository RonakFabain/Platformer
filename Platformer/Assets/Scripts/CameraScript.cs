using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
     GameObject objectToFollow;
    [SerializeField]
     float speed = 2.0f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

        this.transform.position = position;
    }
    //TODO UI System
    //TODO Player Health
    //TODO Enemies
    //TODO Normals
    //TODO Audio
    //TODO Object Pool
    //TODO Death Effect
    //TODO Puzzles and Levels
    


    
}
