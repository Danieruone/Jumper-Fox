﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text coinsText;
    public GameObject gameOverText;
    public GameObject WinText;
    public int coins = 0;

    // Update is called once per frame
    void Update()
    {
        coinsText.text = coins.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead")) {
            Dead();
        }

        if (collision.gameObject.CompareTag("Win")) {
            Win();
        }
    }

    void Win() {
        gameObject.GetComponent<Animator>().SetBool("winCondition", true);
        gameObject.GetComponent<PlayerMovement>().isAlive = false;
        WinText.SetActive(true);
        Invoke("changeScene", 2f);
    }

    void Dead() {
        gameObject.GetComponent<Animator>().SetBool("isAlive", false);
        gameObject.GetComponent<PlayerMovement>().isAlive = false;
        gameOverText.SetActive(true);
        Invoke("changeScene", 2f);
    }

    void changeScene() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
