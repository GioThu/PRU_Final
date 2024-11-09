using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerV1 : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWave = 5f;
    private float countdown;

    private int waveIndex = 0;

    public Text waveCountdownText;

    void Start()
    {
        countdown = timeBetweenWave; 
    }

    void Update()
    {
        if (waveIndex >= waves.Length)
        {
            Debug.Log("All waves spawned");
            return;
        }


        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWave;  
            return;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Spawning wave: " + waveIndex); 
        Wave wave = waves[waveIndex];
        PlayerStats.Rounds++;


        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
        Debug.Log("Enemy spawned, EnemiesAlive: " + EnemiesAlive); 
    }
}
