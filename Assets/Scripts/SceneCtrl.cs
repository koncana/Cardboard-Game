using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneCtrl : MonoBehaviour
{
    private float startChange = 0;
    private float startExit = 0;

    private bool pointedChange = false;
    private bool pointedExist = false;
    private string sceneName;

    void Update()
    {
        if (pointedChange && (Time.time - startChange) >= 0.5)
        {
            SceneManager.LoadScene(this.sceneName);
            pointedChange = false;
        }

        if (pointedExist && (Time.time - startExit) >= 0.8)
        {
            Application.Quit();
            pointedExist = false;
        }
    }

    public void ChangeScene(string sceneName)
    {
        if (!pointedChange)
        {
            this.sceneName = sceneName;
            startChange = Time.time;
            pointedChange = true;
        }
        else
        {
            pointedChange = false;
        }
    }

    public void QuitApp()
    {
        if (!pointedExist)
        {
            startExit = Time.time;
            pointedExist = true;
        }
        else
        {
            pointedExist = false;
        }
    }
}
