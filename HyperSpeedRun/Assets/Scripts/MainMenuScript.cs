using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void HyperSpeedRun2()
    {
        SceneManager.LoadScene("HyperSpeedRun2");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Exit");
    }
}