using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{

    public GameObject StartPanel;
    public GameObject InGame;
    public GameObject LevelCompleted;
    public GameObject LevelFail;
    public GameObject slider;
   
    public Text menuLevelText;
    public static int levelCount=0;
    public Text levelText ;

    
    private void Start()
    {
        GameLevel(1);
          
    }
    private void OnApplicationQuit()
    {
        levelCount = 0;
    }
    public void TapToPlay()
    {
        
        slider.SetActive(true);
        StartPanel.SetActive(false);
        InGame.SetActive(true);
        GameManager.Instance.state = State.selecting;
        Time.timeScale = 1;
    }
    public void Levelfail()
    {
        slider.SetActive(false);
        InGame.SetActive(false);
        StartPanel.SetActive(false);
        LevelFail.SetActive(true);
        GameManager.Instance.state = State.finish;
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        levelCount--;
        menuLevelText.text = (levelText.text);
        slider.SetActive(true);
        LevelFail.SetActive(false);
        InGame.SetActive(true);
        GameManager.Instance.state = State.selecting;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void LevelComp()
    {
        slider.SetActive(false);
        InGame.SetActive(false);
        LevelCompleted.SetActive(true);
        GameManager.Instance.state = State.finish;
        Time.timeScale = 0;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameLevel(int level)
    {
        levelCount += level;
        levelText.text = ("LEVEL " + (levelCount).ToString());
        menuLevelText.text = (levelText.text);
    }
}
