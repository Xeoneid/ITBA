using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardAsset : ScriptableObject {

    public Sprite sprite;
    public CardType cardType;
    public CardValue cardValue;
    public CardColor cardColor;

}

public enum CardType
{
    Clubs,
    Diamonds,
    Hearts,
    Spades,
    Joker
}

public enum CardValue
{
    Joker,
    Ace,
    Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,
    Jack,
    Queen,
    King,
}

public enum CardColor
{
    Red,
    Black
}
