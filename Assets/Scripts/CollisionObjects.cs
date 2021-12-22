using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObjects : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.state = State.selecting;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if ((collision.collider.tag == "unsalvageable" || collision.collider.tag == "salvageable")  && GameManager.Instance.state != State.savior)
        {
            ObjectRandom.Instance.ObjectsRandom();
        }
    }
}
