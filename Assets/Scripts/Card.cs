using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Tooltip("The power level of the card, determining its strength in the game.")]
    public int cardPower;

    [Tooltip("The name of the card.")]
    [SerializeField] string cardName;
}
