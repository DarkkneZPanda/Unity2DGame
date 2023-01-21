using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private AudioSource CoinEffect;
    public TextMeshProUGUI MyMoneyScore;
    private int MoneyNum;

    // Start is called before the first frame update
    void Start()
    {
        MoneyNum = 0;
        MyMoneyScore.text = "Coins : " +  MoneyNum;
    }

    private void OnTriggerEnter2D(Collider2D coin) {
        if(coin.tag == "Coin") {
            CoinEffect.Play();
            MoneyNum += 1;
            MyMoneyScore.text = "Coins : " + MoneyNum;
        }
    }
}
