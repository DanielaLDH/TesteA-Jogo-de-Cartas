using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDeck : MonoBehaviour, IPointerClickHandler
{
    [Tooltip("List of all card prefabs that can be used in the deck.")]
    [SerializeField] List<GameObject> cards;

    [Tooltip("The parent transform where the cards in hand will be instantiated.")]
    [SerializeField] Transform cardHand;

    [Tooltip("The maximum number of cards that can be held in hand.")]
    [SerializeField] int maxQtdCards;

    // Start is called before the first frame update
    void Start()
    {
        InitialCards();
    }

    private void Update()
    {
        if (cards.Count == 0)
        {
            gameObject.SetActive(false);
        }
    }

    void InitialCards()
    {
        for (int i = 0; i < maxQtdCards; i++)
        {
            InstantiateCards();
        }
    }


    void GetNewCard()
    {
        int cardQtd = cardHand.childCount;

        if (cardQtd < maxQtdCards)
        {
            InstantiateCards();
        }
    }

    void InstantiateCards()
    {
        int randonCard = Random.Range(0, cards.Count);

        GameObject newCard = Instantiate(cards[randonCard], cardHand);

        newCard.GetComponent<RectTransform>().localScale = Vector3.one;
        newCard.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        cards.RemoveAt(randonCard);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetNewCard();
    }
}
