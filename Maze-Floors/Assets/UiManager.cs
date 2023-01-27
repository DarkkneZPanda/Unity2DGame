using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable() {
        DamageableCharacter.GameOver += EnableGameOver;
    }

    private void OnDisable() {
        DamageableCharacter.GameOver -= EnableGameOver;
    }

    public void EnableGameOver() {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame() {
        SceneManager.LoadScene(0);
    }
}
