using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardDatabase : ScriptableObject
{
    public Card[] cards;
    
    public Card GetRandomCardFromDatabase()
    {
        return cards[Random.Range(0, cards.Length)];
    }
}
