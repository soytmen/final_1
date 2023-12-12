using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes : MonoBehaviour
{
    public void LoadGame(int escena)
    {
        if (escena == -1)
        {
            Application.Quit();
            Debug.Break();
            return;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(escena);
    }
}

