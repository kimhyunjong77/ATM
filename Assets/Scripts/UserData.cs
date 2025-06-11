using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string Name;
    public string ID;
    public string PassWord;
    public int Cash;
    public int Balance;

    public UserData(string name, string iD, string passWord, int cash, int balance)
    {
        this.Name = name;
        this.ID = iD;
        this.PassWord = passWord;
        this.Cash = cash;
        this.Balance = balance;
    }
}
