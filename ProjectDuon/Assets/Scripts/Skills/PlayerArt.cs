using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArt : GeneralArt {

    public List<GeneralSkill> requirements;
    public string description;



    public PlayerArt(string name, int staminaCost, string description = "", List<GeneralSkill> requirements = null, Sprite icon = null, List<BasicSkillType> basicSkillRequirements = null)
    {
        this.name = name;
        this.staminaCost = staminaCost;
        this.description = description;
        this.requirements = requirements;
        this.icon = icon;
        this.basicSkillRequirements = basicSkillRequirements;
    }

}
