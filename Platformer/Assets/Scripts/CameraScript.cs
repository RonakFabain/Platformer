using UnityEngine;

//TODO UI System
//TODO Parallax
//TODO Enemies
//TODO Audio
//TODO Object Pool
//TODO Death Effect
//TODO Puzzles and Levels
public class CameraScript : MonoBehaviour
{
   
    [SerializeField] float speed = 2.0f;
    [SerializeField] float leftMax = 2.0f;
    [SerializeField] float rightMax = 2.0f;
    [SerializeField] float downMax = 2.0f;
    [SerializeField] float topMax = 2.0f;
    float offset;
    [SerializeField] float boundX = -20;
    Vector3 pos;
    bool move = false;



    private void Start()
    {

    }

    private void Update()
    {
       // offset = (LookAt.transform.position.x) - (transform.position.x);
    }
    void LateUpdate()
    {

       

        
        if (offset >= boundX )
        {
            offset = 0;
            NextLevel();



        }


        pos = new Vector3
            (
            Mathf.Clamp(transform.position.x , leftMax, rightMax),
            Mathf.Clamp(transform.position.y, downMax, topMax),
            transform.position.z
            );

        transform.position = pos;

    }



    void  NextLevel()
    {
     
        transform.position = new Vector3(transform.position.x + 40, transform.position.y, transform.position.z);
        leftMax += 35;
        rightMax += 35;
        StopCoroutine("NextLevel");
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(new Vector2(leftMax, topMax), new Vector2(rightMax, topMax));
    //    Gizmos.DrawLine(new Vector2(rightMax, topMax), new Vector2(rightMax, downMax));
    //    Gizmos.DrawLine(new Vector2(rightMax, downMax), new Vector2(leftMax, downMax));
    //    Gizmos.DrawLine(new Vector2(leftMax, downMax), new Vector2(leftMax, topMax));
    //}

}
