using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    // Карта
    public GameManager gameManager;
    public GameObject card;
    // UI иконки
    public Image personHealth;
    public Image personStrength;
    public Image personMoney;
    public Image personBrain;
    // UI изменения иконок
    public Image personHealthImpact;
    public Image personStrengthImpact;
    public Image personMoneyImpact;
    public Image personBrainImpact;
    void Update()
    {
        // UI иконки
        personHealth.fillAmount = (float)GameManager.personHealth / GameManager.maxValue;
        personStrength.fillAmount = (float)GameManager.personStrength / GameManager.maxValue;
        personMoney.fillAmount = (float)GameManager.personMoney / GameManager.maxValue;
        personBrain.fillAmount = (float)GameManager.personBrain / GameManager.maxValue;

        // UI изменения иконок
        // Вправо
        if (gameManager.direction == "right")
        {
            if(gameManager.currentCard.pHealthRight !=0)
                personHealthImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.pStrengthRight != 0)
                personStrengthImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.pMoneyRight != 0)
                personMoneyImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.pBrainRight != 0)
                personBrainImpact.transform.localScale = new Vector3(1, 1, 0);
        }
        // Влево
        else if (gameManager.direction == "left")
        {
            if (gameManager.currentCard.pHealthLeft != 0)
                personHealthImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.pStrengthLeft != 0)
                personStrengthImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.pMoneyLeft != 0)
                personMoneyImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.pBrainLeft != 0)
                personBrainImpact.transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            personHealthImpact.transform.localScale = new Vector3(0,0,0);
            personStrengthImpact.transform.localScale = new Vector3(0, 0, 0);
            personMoneyImpact.transform.localScale = new Vector3(0, 0, 0);
            personBrainImpact.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
