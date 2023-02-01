using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelConditions : MonoBehaviour
{
    [SerializeField] private AudioSource LevelFinishedEffect;
    public GameObject BossEnemy;

    public GameObject levelMove;

    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other) {
        if(BossEnemy.gameObject.activeSelf == false) {
            levelMove.SetActive(true);
            LevelFinishedEffect.Play();
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        } else {
            levelMove.SetActive(false);
        }
    }


   
}
