using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleSandwich : Item
{

	public TripleSandwich()
    {
        itemName = "Triple Sandwich";
        description = "Towering three-level sandwich.\nRestores 50% of total HP.";
    }

    public override void OnUse(PlayableCharacter character)
    {
        character.health += Mathf.RoundToInt(character.maxHealth / 2f);
        character.health = Mathf.Min(character.health, character.maxHealth);
    }
}
