using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public static PoolManager Instance;

    [System.Serializable]
    public class ObjectData
    {
        public string oTag;
        public int oSize;
        public GameObject oPrefab;
        public bool canExpand = false;
    }

    public List<ObjectData> poolClass = new List<ObjectData>();
    [HideInInspector]
    public List<GameObject> poolObject = new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

    }

    public GameObject getPool(string tag)
    {

        for (int i = 0; i < poolObject.Count; i++)
        {
            if (!poolObject[i].activeInHierarchy && poolObject[i].tag == tag)

                return poolObject[i];

        }
        foreach (ObjectData o in poolClass)
        {
            if (o.oTag == tag)
            {
                if (o.canExpand)
                {
                    GameObject g = Instantiate(o.oPrefab);
                    g.SetActive(false);
                    poolObject.Add(g);
                    return g;
                }
            }
        }

        return null;

    }


    void Start()
    {
        foreach (ObjectData o in poolClass)
        {
            for (int i = 0; i < o.oSize; i++)
            {
                GameObject g = (GameObject)Instantiate(o.oPrefab);
                g.SetActive(false);
                poolObject.Add(g);
            }
        }
    }


}
