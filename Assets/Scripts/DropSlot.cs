using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject droppedCard = eventData.pointerDrag;
            Card droppedCardScript = droppedCard.GetComponent<Card>();
            RectTransform droppedCardRect = eventData.pointerDrag.GetComponent<RectTransform>();

            int childCount = transform.childCount;
            if (childCount > 0)
            {
                Card lastCard = transform.GetChild(childCount - 1).GetComponent<Card>();

                if (droppedCardScript.cardPower > lastCard.cardPower) 
                {
                    droppedCardRect.SetParent(transform);
                    droppedCardRect.localScale = Vector3.one;
                    droppedCardRect.localPosition = Vector2.zero;
                }
                else
                {
                    Debug.Log("Você só pode soltar cartas em ordem crescente.");
                    droppedCardRect.SetParent(eventData.pointerDrag.transform.parent);
                    droppedCardRect.anchoredPosition = Vector2.zero;
                }

            }
            else
            {
                droppedCardRect.SetParent(transform);
                droppedCardRect.localPosition = Vector2.zero;
                droppedCardRect.localScale = Vector3.one;
            }

        }
    }
}
