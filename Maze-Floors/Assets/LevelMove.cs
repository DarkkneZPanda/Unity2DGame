using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    [SerializeField] private AudioSource LevelFinishedEffect;
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            LevelFinishedEffect.Play();
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

        }
    }
}
