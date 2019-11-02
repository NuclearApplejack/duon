using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBasicSkill : GeneralBasicSkill {

    public List<GeneralSkill> requirements;
    public string description;

    public PlayerBasicSkill(string name, BasicSkillType type, int staminaCost, float cooldown, Vector2 velocity, string description = "", Sprite icon = null, List<GeneralSkill> requirements = null)
    {
        this.name = name;
        this.type = type;
        this.staminaCost = staminaCost;
        this.cooldown = cooldown;
        this.velocityMod = velocity;
        this.description = description;
        this.icon = icon;
        this.requirements = requirements;
    }

}
