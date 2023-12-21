using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Moves to next scene
    public void NextScene() {
        if (SceneManager.GetActiveScene().buildIndex < 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            LevelSelect();
        }
    }
    // Goes back a scene
    public void PrevScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Restarts the scene
    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Returns to level select screen
    public void LevelSelect() {
        SceneManager.LoadScene(0);
    }
}
