using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource levelCompliteSound;
    [SerializeField] private AudioSource gameoverSound;
    // Start is called before the first frame update
    void Start()
    {
        PlayerDetection.onDoorsHit += PlayDoorHitsSound;

        GameManager.onGameStateChanged += GameStateChangedCallback;

        Enemy.onRunnerDied += PlayRunnerDieSound;
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorsHit -= PlayDoorHitsSound;

        GameManager.onGameStateChanged -= GameStateChangedCallback;

        Enemy.onRunnerDied -= PlayRunnerDieSound;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.LevelComplete)
            levelCompliteSound.Play(); 
        else if(gameState == GameManager.GameState.Gameover)
            gameoverSound.Play();
    }

    private void PlayDoorHitsSound ()
    {
        doorHitSound.Play();
    }

    private void PlayRunnerDieSound()
    {
        runnerDieSound.Play();
    }

    public void DisableSounds()
    {
        doorHitSound.volume = 0;
        runnerDieSound.volume = 0;
        levelCompliteSound.volume = 0;
        gameoverSound.volume = 0;
        buttonSound.volume = 0;
    }

    public void EnableSounds()
    {
        doorHitSound.volume = 1;
        runnerDieSound.volume = 1;
        levelCompliteSound.volume = 1;
        gameoverSound.volume = 1;
        buttonSound.volume = 1;

    }
}
