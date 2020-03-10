
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    [Header("Attributes")]

    public static int EnemiesAlive = 0;

    public float timeBetweenWaves = 5f;

    private float countdown = 2f;

    public Text WaveCountdownText;

    [Header("Unity Setup Fields")]

    //public Transform enemyPrefab;

    public Wave[] waves;

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

        // if there are still enemies alive in the game, don't spawn a new wave
        // Todo: change this later if we want to generate new enemies while enemies are still alive
        if (EnemiesAlive > 0)
        {
            return;
        }

        // if countdown = 0, spawn a wave and reset countdown
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
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
        //waveIndex++;

        //each time a new wave of enemies is spawned, the player has survived another round
        //Todo: maybe change later to keep track of if the enemies of a "round" have been killed
        // and use that to keep track of how many rounds player has survived
        PlayerStats.Rounds++;

        // get the wave that will be generated
        Wave wave = waves[waveIndex];

        // spawns waveIndex number of enemies, each enemy has a gap of .5 seconds to  next enemy
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        waveIndex++;

        // Todo: try to generate enemies that get harder and harder for survival mode instead of cycling through the same ones
        //       may have to change structure from array to list so that we can change the size?
        // if we have generated the last wave, set waveIndex back to 0 so we can cycle through the waves again 
        if (waveIndex == waves.Length)
        {
            waveIndex = 0;
        }

    }

    /* SpawnEnemy()
     *
     * Instantiates enemy prefab that is passed in at spawn point
     *
     * TODO: if want to add more enemy spawning locations, edit this and spawn position stuff
     * 
     */
    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
