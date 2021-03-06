using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // ПЕРСОНАЖ
    public static int personHealth = 50;
    public static int personStrength = 50;
    public static int personMoney = 50;
    public static int personBrain = 50;
    public static int maxValue = 100;
    public int minValue = 0;

    // Объекты
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    public Vector2 defaultPositionCard;    
    // Переменные
    public float fMovingSpeed;
    public float fRotatingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public float divideValue;
    public float backgroundDivideValue;
    float alphaText;
    public Color textColor;
    public Color actionBackgroundColor;
    public float fTransparency = 0.7f;
    public float fRotationCoefficient;
    Vector3 pos;
    // UI
    public TMP_Text display;
    public TMP_Text characterDialogue;
    public TMP_Text actionQuote;
    public SpriteRenderer actionBackground;
    // Карты
    public string direction;
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;
    // Замена карты
    public bool isSubstituting = false;
    public Vector3 cardRotation; // дефолтное
    public Vector3 currentRotation; // текущее вращение карты
    public Vector3 initRotation; // начальное значение вращения карты

    void Start()
    {
        LoadCard(testCard);
    }    

    void Update()
    {
        // Логика значений персонажа

        // Текст диалога
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, 1);
        actionBackgroundColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / backgroundDivideValue, fTransparency);
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            direction = "right";
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                NewCard();
            }
        }
        else if (cardGameObject.transform.position.x > fSideMargin)
        {
            direction = "right";
        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            direction = "none";
            textColor.a = 0;
        }
        else if (cardGameObject.transform.position.x > -fSideTrigger)
        {
            direction = "left";
        }
        else
        {
            direction = "left";
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                NewCard();
            }            
        }
        UpdateDialogue();
        // Движение
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
            // Поворот карты
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, cardGameObject.transform.position.x * fRotationCoefficient);
        }
        else if (!isSubstituting)
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, defaultPositionCard, fMovingSpeed);
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (isSubstituting)
        {
            cardGameObject.transform.eulerAngles = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, cardRotation, fRotatingSpeed);

        }
        //UI
        display.text = "" + textColor.a;

        characterDialogue.text = currentCard.dialogue;

        // Поворот карты
        if (cardGameObject.transform.eulerAngles == cardRotation)
        {
            isSubstituting = false;
        }
    }
    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        actionBackground.color = actionBackgroundColor;
        if (cardGameObject.transform.position.x < 0)
        {
            actionQuote.text = leftQuote;
        }
        else
        {
            actionQuote.text = rightQuote;
        }
    }
    public void LoadCard(Card card)
    {
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        characterDialogue.text = card.dialogue;
        currentCard = card;
        // Сброс позиции карты
        cardGameObject.transform.position = defaultPositionCard;
        cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        // Инициализирую замену карты
        isSubstituting = true;
        cardGameObject.transform.eulerAngles = initRotation;
    }
    public void NewCard()
    {
        int rollDice = Random.Range(0, resourceManager.cards.Length);
        LoadCard(resourceManager.cards[rollDice]);
    }
    
}