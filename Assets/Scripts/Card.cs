using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card : ScriptableObject
{
    // Базовые значения карт
    public int cardID;
    public string cardName;
    public CardSprite sprite;
    public string dialogue;
    public string leftQuote;
    public string rightQuote;
    // Связующие значения
    // Влево
    public int pHealthLeft;
    public int pStrengthLeft;
    public int pMoneyLeft;
    public int pBrainLeft;
    // Вправо
    public int pHealthRight;
    public int pStrengthRight;
    public int pMoneyRight;
    public int pBrainRight;
    public void Left()
    {
        Debug.Log(cardName + " влево");
        // Изменение значений
        GameManager.personHealth += pHealthLeft;
        GameManager.personStrength += pStrengthLeft;
        GameManager.personMoney += pMoneyLeft;
        GameManager.personBrain += pBrainLeft;
    }

    public void Right()
    {
        Debug.Log(cardName + " вправо");
        // Изменение значений
        GameManager.personHealth += pHealthRight;
        GameManager.personStrength += pStrengthRight;
        GameManager.personMoney += pMoneyRight;
        GameManager.personBrain += pBrainRight;
    }
}
