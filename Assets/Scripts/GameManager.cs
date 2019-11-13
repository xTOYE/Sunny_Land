using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public int score = 0;

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UIManager.Instance.UpdateScore(score);
    }


    public void NextScene()
    {
        // Get current scene
        Scene activeScene = SceneManager.GetActiveScene();
        // Load next scene
        SceneManager.LoadScene(activeScene.buildIndex + 1);
    }

    public void ResetScene()
    {
        // Get current scene
        Scene activeScene = SceneManager.GetActiveScene();
        // Load next scene
        SceneManager.LoadScene(activeScene.buildIndex);
    }
}
