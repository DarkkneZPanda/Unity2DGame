using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectible
{
    [SerializeField] private AudioSource Coinpickup;
    private void OnEnable() {
        // Coin.OnCoinCollected += CoinSound;
    }

    private void OnDisable() {
        // Coin.OnCoinCollected -= CoinSound;
    }
    public static event CoinsCollected OnCoinCollected;
    public delegate void CoinsCollected(ItemData itemData);
    public ItemData coinData;
    public void Collect()
    {
        Destroy(gameObject);
        OnCoinCollected?.Invoke(coinData);
    }

    public void CoinSound() {
        Coinpickup.Play();
    }
}
