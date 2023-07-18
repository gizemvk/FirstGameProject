using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Device;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameWinText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timeText;

    public int maxHealth = 3;
    private int currentHealth;
    private int score;
    private int geriSayac;

    private bool isGameOver = false;
    private bool isGameWin = false;

    private void Start()
    {
        currentHealth = maxHealth;
        healthText.text = "Health : " + currentHealth.ToString();
        score = 0;
        scoreText.text = "Score : " + score.ToString();

        StartCoroutine(TimeRoutine());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Application.Quit();
        }
    }
    private IEnumerator TimeRoutine()
    {
        
        geriSayac = 51;

        while (geriSayac > 0)
        {
            yield return new WaitForSeconds(1f);
            geriSayac--;
            timeText.text = "Time : " + geriSayac.ToString();

            if (geriSayac <= 0 && !isGameWin)
            {
                StartCoroutine(GameOverSequence());
            }
           
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        
         if (other.gameObject.CompareTag("Gold"))
        {
            score += 5;
            scoreText.text = "Score : " + score.ToString();
            Destroy(other.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            ReduceHealth();
        }

        else if (collision.gameObject.CompareTag("Exit") && geriSayac > 0 && currentHealth > 0)
        {
            if (currentHealth > 0 && geriSayac > 0)
            {
                StartCoroutine(GameWinSequence());
                
            } 
            
            StopCoroutine(GameOverSequence());

           

        }
    }

    private void ReduceHealth()
    {
        currentHealth--;
        healthText.text = "Health : " + currentHealth.ToString();

        if (currentHealth <= 0 && !isGameWin)
        {
            StartCoroutine(GameOverSequence());
        }
    }

    private IEnumerator GameWinSequence()
    {
        gameWinText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private IEnumerator GameOverSequence()
    {
        gameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
