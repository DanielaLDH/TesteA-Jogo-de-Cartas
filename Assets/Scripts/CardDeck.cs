using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDeck : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] List<GameObject> cards;
    [SerializeField] Transform cardHand;
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

        if (cardQtd < maxQtdCards && cards.Count >0)
        {
            InstantiateCards();
        }
    }

    void InstantiateCards()
    {
        if (cards.Count == 0)
        {
            Debug.Log("No more cards available");
            return;
        }

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
