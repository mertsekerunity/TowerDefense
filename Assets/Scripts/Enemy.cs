using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int coinReward = 25;
    [SerializeField] int coinPenalty = 25;

    Bank bank;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RewardCoins()
    {
        if (bank == null) { return; }
        bank.Deposit(coinReward);
    }

    public void PenaltyCoins()
    {
        if (bank == null) { return; }
        bank.Withdraw(coinPenalty);
    }
}
