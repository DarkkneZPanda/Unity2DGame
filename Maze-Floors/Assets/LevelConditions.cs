using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelConditions : MonoBehaviour
{
    [SerializeField] private AudioSource LevelFinishedEffect;
    public DamageableCharacter EndGame;

    public int sceneBuildIndex;

    public GameObject ClosedDoor; 

    private void OnTriggerEnter2D(Collider2D other) {
        if(EndGame == null) {
            LevelFinishedEffect.Play();
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            ClosedDoor.gameObject.SetActive(false);
        }
    }


   
}
