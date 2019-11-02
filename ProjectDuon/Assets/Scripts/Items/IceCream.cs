using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCream : Item
{

	public IceCream()
    {
        itemName = "Ice Cream";
        description = "Bowl of ice cream supplied by Antony.\nRestores 25% of total HP.";
    }

    public override void OnUse(PlayableCharacter character)
    {
        character.health += Mathf.RoundToInt(character.maxHealth / 4f);
        character.health = Mathf.Min(character.health, character.maxHealth);
    }
}
