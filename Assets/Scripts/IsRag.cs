using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRag : Singleton<IsRag>
{
    public GameObject noRag;
    public GameObject rag;

    private void Start()
    {
        noRag.SetActive(true);
        rag.SetActive(false);
    }
    
}
