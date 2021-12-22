using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum State{
    start,
    selecting,
    savior,
    finish
}
public class GameManager : Singleton<GameManager>
{
    public State state = State.start;
    public GameObject confetti;

    public GameObject[] salvageableObjectsCount;
    public List<GameObject> salvageableObjects;
    private void Start()
    {
        salvageableObjectsCount = GameObject.FindGameObjectsWithTag("salvageable");
    }

    private void Update()
    {
        if (salvageableObjectsCount.Length == salvageableObjects.Count)
        {
            StartCoroutine(DelayLevelCompPanel());
            StartCoroutine(Confetti());
            state = State.finish;
        }
        if (salvageableObjectsCount == null)
        {
            Time.timeScale = 0;
        }
    
    }

    IEnumerator DelayLevelCompPanel()
    {
        yield return new WaitForSeconds(2.5f);
        UIManager.Instance.LevelComp();
    }
    IEnumerator Confetti()
    {
        confetti.SetActive(true);
 
        yield return new WaitForSeconds(.5f);
    }


}
