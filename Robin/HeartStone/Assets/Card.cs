using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

	public new string name;
	public string description;
    public string race;

    public bool legandary;

	public Sprite artwork;

	public int manaCost;
	public int attack;
	public int health;
}

[CreateAssetMenu(fileName = "New Card", menuName = "AbilityCard")]
public class AbilityCard : Card
{
//   public Ability ability;

    public void ExecuteAbility()
    {
//        ability.Execute();
    }
}