using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilithsChickenSoup : Item
{
    public LilithsChickenSoup()
    {
        itemName = "Lilith's Chicken Soup";
        description = "Home-cooked pot of Lilith's revitalizing chicken soup.\nRestores all HP.";
    }

    public override void OnUse(PlayableCharacter character)
    {
        character.health =  character.maxHealth;
    }
}
