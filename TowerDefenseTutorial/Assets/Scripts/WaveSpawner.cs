
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    [Header("Attributes")]

    public float timeBetweenWaves = 5f;

    private float countdown = 2f;

    public Text WaveCountdownText;

    [Header("Unity Setup Fields")]

    public Transform enemyPrefab;

    public Transform spawnPoint;

    private int waveIndex = 0;

    /* Update() - every frame
     * 
     * determines if wave should spawn this frame
     *
     * decreases countdown to next wave and updates wave countdown text
     *
     */
    private void Update()
    {
        // if countdown = 0, spawn a wave and reset countdown
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        // decrease countdown by amount of time passed since last frame
        countdown -= Time.deltaTime;
        // makes sure countdown never is  below 0
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        // update wave countdown text
        WaveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    /* SpawnWave()
     *
     * spawns correct number of enemies for a wave
     * 
     */
    IEnumerator SpawnWave()
    {
        // in this wave spawning, there's just one more enemy per wave
        // so here, increase index to  show another wave is happening
        waveIndex++;
        //each time a new wave of enemies is spawned, the player has survived another round
        //Todo: maybe change later to keep track of if the enemies of a "round" have been killed
        // and use that to keep track of how many rounds player has survived
        PlayerStats.Rounds++; 
        // spawns waveIndex number of enemies, each enemy has a gap of .5 seconds to  next enemy
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);
        }
        
    }

    /* SpawnEnemy()
     *
     * Instantiates enemy prefab at spawn point
     *
     * TODO: if want to add more enemy spawning locations, edit this and spawn position stuff
     * 
     */
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
