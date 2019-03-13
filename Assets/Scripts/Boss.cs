using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using ExtensionMethods;

public class Boss : MonoBehaviour {

    public List<Card> bossCards;
    public Transform[] bossCardsPositions;
    public Boss instance;
    public Transform[] playerCardsPositions;
    public List<Card> playerCards;
    public Text text;
    public float tweeningTime = 1f;

    private const string NOT_ENOUGH_CARDS = "Four cards are needed to play this hand";
    private const string DEFAULT = "Why is it you're always too small or too tall?";
    private const string SHOW_ME_YOUR_CARDS = "Let's play!";
    private const string PLAYER_WINS = "It's impossible";

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
        text.text = DEFAULT;
    }

    bool isTweening = false;

    public void PlayCards()
    {
        if (Player.instance.cardsHand.Count == 4)
        {
            text.text = SHOW_ME_YOUR_CARDS;
            int iteration = 0;
            isTweening = true;
            foreach (var item in bossCards)
            {
                item.transform.DOMove(bossCardsPositions[iteration].position, tweeningTime).OnComplete(() => { isTweening = false; });
            }
            this.WaitUntilAndExecute(
                () =>
                {
                    int iteration2 = 0;
                    foreach (var item in Player.instance.cardsHand)
                    {
                        item.transform.DOMove(playerCardsPositions[iteration2].position, tweeningTime);
                    }
                    text.text = PLAYER_WINS;
                },
                () => { return !this.isTweening; });
        }
        else
            text.text = NOT_ENOUGH_CARDS;
    }
}
