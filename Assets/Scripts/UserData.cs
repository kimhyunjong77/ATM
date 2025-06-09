using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string Name;
    public int Cash;
    public int Balance;

    public UserData(string name, int cash, int balance)
    {
        this.Name = name;
        this.Cash = cash;
        this.Balance = balance;
    }
}
