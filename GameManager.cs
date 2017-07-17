using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Canvas StopCanvas;
    public Text KillPoint;
    public Text GameOverKillPoint;
    public Text SurvicePoint;
    public Text TotalPoint;
    private int i;
    private float timer;

    private void Start()
    {
        KillPoint.text = "0";
        GameOverKillPoint.text = "0";
        SurvicePoint.text = "0";
        TotalPoint.text = "0";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (StopCanvas.enabled == false)
            {
                StopCanvas.enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                StopCanvas.enabled = false;
                Time.timeScale = 1;
            }
        }

        timer += Time.deltaTime;

    }

    public void yesClick()
    {
        Application.Quit();
    }

    public void noClick()
    {
        StopCanvas.enabled = false;
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1;
    }

    public void KillPointManager(int point)
    {
        int.TryParse(KillPoint.text, out i);
        i += point;
        KillPoint.text = i.ToString();
        GameOverKillPoint.text = KillPoint.text;
    }

    public void TotalPointManager()
    {
        int a, b;
        SurvicePoint.text = ((int)timer).ToString();
        int.TryParse(KillPoint.text, out a);
        int.TryParse(SurvicePoint.text, out b);
        TotalPoint.text = (a + b).ToString();
    }
}
