using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string ScenesName;

    public void ChangeS()
    {
        SceneManager.LoadScene(ScenesName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
