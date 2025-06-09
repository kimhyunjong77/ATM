using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public UIManager uIManager;
    public TMP_InputField dInputField;
    public TMP_InputField wInputField;

    public void OnClickDepositButton(int amount)
    {
        if (GameManager.Instance == null || GameManager.Instance.userData == null)
            return;

        UserData data = GameManager.Instance.userData;

        if (data.Cash < amount)
        {
            Debug.Log("현금이 부족합니다.");
            return;
        }

        if (data.Balance < -amount)
        {
            Debug.Log("잔액이 부족합니다.");
            return;
        }

        data.Cash -= amount;
        data.Balance += amount;

        GameManager.Instance.SaveUserData();

        if (uIManager != null)
        {
            uIManager.Refresh();
        }
    }

    public void OnClickWithdrawalButton(int amount)
    {
        if (GameManager.Instance == null || GameManager.Instance.userData == null)
            return;

        UserData data = GameManager.Instance.userData;

        if (data.Cash < -amount)
        {
            Debug.Log("현금이 부족합니다.");
            return;
        }

        if (data.Balance < amount)
        {
            Debug.Log("잔액이 부족합니다.");
            return;
        }

        data.Cash += amount;
        data.Balance -= amount;

        GameManager.Instance.SaveUserData();

        if (uIManager != null)
        {
            uIManager.Refresh();
        }
    }

    public void OnClickDepositInput()
    {
        if (!int.TryParse(dInputField.text, out int amount) || amount <= 0)
        {
            Debug.Log("입금 금액이 올바르지 않습니다.");
            return;
        }

        OnClickDepositButton(amount);
        dInputField.text = "";
    }

    public void OnClickWithdrawalInput()
    {
        if (!int.TryParse(wInputField.text, out int amount) || amount <= 0)
        {
            Debug.Log("입금 금액이 올바르지 않습니다.");
            return;
        }

        OnClickWithdrawalButton(amount);
        wInputField.text = "";
    }
}
