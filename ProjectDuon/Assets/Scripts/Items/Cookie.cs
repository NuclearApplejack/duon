using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : Item {

	public Cookie()
    {
        itemName = "Cookie";
        description = "Regular cookie with chocolate chips.\nRestores 10% of total HP.";
    }

    public override void OnUse(PlayableCharacter character)
    {
        character.health += Mathf.RoundToInt(character.maxHealth / 10f);
        character.health = Mathf.Min(character.health, character.maxHealth);
    }
}
