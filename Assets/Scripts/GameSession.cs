using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    public static int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    public int numOfHearts;
    public UnityEngine.UI.Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    //public GameOver gameOver;

    void Start()
    {
        scoreText.text = score.ToString();
    }
    void Update() // UI hearts update 
    {
        // if (playerLives > numOfHearts)
        // {
        //     playerLives = numOfHearts;
        // }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerLives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }


    }
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();

    }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            StartCoroutine(Takelife());
        }
        else
        {
            ResetGameSession();
        }
    }

    IEnumerator Takelife()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    // void TakeLife()
    // {

    //     playerLives--;
    //     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(currentSceneIndex);


    // }

    public void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(7);
        Destroy(gameObject);
    }
}
//     void Restart()
//     {
//         Destroy(gameObject);
//         FindObjectOfType<ScenePersist>().ResetScenePersist();
//     }

//     void Quit()
//     {

//     }
// }
