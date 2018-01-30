using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

	public Card card;

    public Text nameText = null;
	public Text descriptionText = null;

	public Image artworkImage = null;

	public Text manaText = null;
	public Text attackText = null;
	public Text healthText = null;

	// Use this for initialization
	public void Setup(Card card)
    {
        this.card = card;

        if (nameText != null)
        {
            nameText.text = this.card.name;
        }

        if (descriptionText != null)
        {
            descriptionText.text = card.description;
        }

        if (artworkImage != null)
        {
            artworkImage.sprite = card.artwork;
        }

        if (artworkImage != null)
        {
            artworkImage.sprite = card.artwork;
        }

        if (artworkImage != null)
        {
            artworkImage.sprite = card.artwork;
        }

        if (manaText != null)
        {
            manaText.text = card.manaCost.ToString();
        }

		attackText.text = card.attack.ToString();
		healthText.text = card.health.ToString();

        transform.name = card.name;
	}
}
