using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    int count;

    private void OnEnable() {
        // Coin.OnCoinCollected += IncrementCoinCount;
    }

    private void OnDisable() {
       // Coin.OnCoinCollected -= IncrementCoinCount;
    }

    public void IncrementCoinCount() {
        count++;
        coinCount.text = $"Coins: {count}";
    }
}
