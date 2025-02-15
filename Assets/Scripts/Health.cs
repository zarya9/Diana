using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject minusHealthPanel;
    public List<GameObject> hearts;
    public int count = 2;
    public GameObject gameOverImage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orange"))
        {
            if (hearts.Count > 0)
            {
                hearts[count].SetActive(false);
                hearts.RemoveAt(count);
                minusHealthPanel.SetActive(true);
                count--;

                if (hearts.Count == 0)
                {
                    StartCoroutine(EndGame());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orange"))
        {
            try
            {
                minusHealthPanel.SetActive(false);
            }
            catch { }
        }
    }

    private IEnumerator EndGame()
    {
        Time.timeScale = 0;
        gameOverImage.SetActive(true);

        yield return null;
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        gameOverImage.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}