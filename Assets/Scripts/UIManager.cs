using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;

    public GameObject PopupBankpanel;
    public GameObject DepositPanel;
    public GameObject WithdrawalPanel;
    public GameObject UserInfoPanel;
    public GameObject PopupLoginPanel;
    public GameObject AtmPanel;
    public GameObject PopupSignUpPanel;
    public GameObject ErrorPanel;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (GameManager.Instance == null || GameManager.Instance.userData == null)
            return;

        UserData data = GameManager.Instance.userData;

        nameText.text = $"{data.Name}";
        cashText.text = $"{data.Cash}";
        balanceText.text = $"{data.Balance}";
    }

    public void OnClickDepositButton()
    {
        PopupBankpanel.SetActive(false);
        DepositPanel.SetActive(true);
        WithdrawalPanel.SetActive(false);
    }

    public void OnClickWithdrawButton()
    {
        PopupBankpanel.SetActive(false);
        DepositPanel.SetActive(false);
        WithdrawalPanel.SetActive(true);
    }

    public void OnClickBackButton()
    {
        PopupBankpanel.SetActive(true);
        DepositPanel.SetActive(false);
        WithdrawalPanel.SetActive(false);
    }

    public void OnClickLoginButton()
    {
        PopupLoginPanel.SetActive(false);
        UserInfoPanel.SetActive(true);
        AtmPanel.SetActive(true);
    }

    public void OnClickPopupSignUpPanelButton()
    {
        PopupSignUpPanel.SetActive(true);
    }

    public void OnClickSignUpButton()
    {
        PopupSignUpPanel.SetActive(false);
    }

    public void OnClickCancelButton()
    {
        PopupSignUpPanel.SetActive(false);
    }

    public void OnClickOkButton()
    {
        ErrorPanel.SetActive(false);
    }
}
