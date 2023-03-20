using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Restart : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject ScoreUI;
    public GameObject playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRestart()
    {
        // æ¿ ¿ÁΩ√¿€
        Time.timeScale = 1;
        ScoreUI.SetActive(true);
        GameOverUI.SetActive(false);
        playerController.GetComponent<PlayerController>().isGamePlay = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
