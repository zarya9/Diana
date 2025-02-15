using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawner : MonoBehaviour
{
    public GameObject OrangePrefab;
    public List<Transform> SpawnPoints;
    public GameObject pausePanel;

    private float speedSpawn = 3f;

    IEnumerator Spawner()
    {
        while (true) 
        {
            yield return new WaitForSeconds(speedSpawn);
            if (speedSpawn > 1.3f) speedSpawn *= 0.95f;
            var point = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
            Instantiate(OrangePrefab, point.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void Start()
    {
        StartCoroutine(Spawner()); 
    }

    void TogglePause()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }
}