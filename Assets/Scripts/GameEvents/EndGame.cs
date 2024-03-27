using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    [SerializeField] private GameObject whiteFadeIn;
    [SerializeField] private GameObject whiteFadeOut;
    public Boolean gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {

        whiteFadeOut.SetActive(true);
    }

    public void onWin()
    {
        gameEnded = true;
        whiteFadeIn.SetActive(true);
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            StartCoroutine(LoadMainMenu());
        }
        else
        {
            StartCoroutine(LoadNextScene());
        }
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    public void onLose()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var animator = player.GetComponentInChildren<Animator>();
        animator.SetBool("isDying", true);

        gameEnded = true;
        whiteFadeIn.SetActive(true);
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
