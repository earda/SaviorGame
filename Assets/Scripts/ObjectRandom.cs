using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandom : Singleton<ObjectRandom>
{
    public List<GameObject> objects = new List<GameObject>();
    void Start()
    {
        ObjectsRandom();
    }
    
    public void ObjectsRandom()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.position = new Vector3(Random.Range(-6f, 6f), 0.5f, Random.Range(20f, 70f));
        }
    }

    
}
