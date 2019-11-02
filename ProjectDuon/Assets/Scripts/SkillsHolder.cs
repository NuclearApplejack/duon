using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SkillsHolder {

    static List<BasicSkillType> TestM()
    {
        List<BasicSkillType> testList = new List<BasicSkillType>();
        testList.Add(BasicSkillType.STRIKE);
        testList.Add(BasicSkillType.STRIKE);
        testList.Add(BasicSkillType.STRIKE);
        return testList;
    }

    static List<BasicSkillType> TestL()
    {
        List<BasicSkillType> testList = new List<BasicSkillType>();
        testList.Add(BasicSkillType.SLASH);
        testList.Add(BasicSkillType.MOVEMENT);
        testList.Add(BasicSkillType.BLAST);
        return testList;
    }

    public static GeneralSkill markSkillSlot1 = new PlayerBasicSkill("Punch", BasicSkillType.STRIKE, 60, 0.5f, new Vector2(0, 0), "Throw a simple punch forward.\nPress Q as Mark to execute.", Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/punch icon"));
    public static GeneralSkill markSkillSlot2 = new PlayerBasicSkill("Ground Pound", BasicSkillType.BLAST, 60, 0.5f, new Vector2(0, 0), "Punch the ground to create a fiery shockwave.\nPress W as Mark to execute.", Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/ground pound icon"));
    public static GeneralSkill markSkillSlot3 = new PlayerBasicSkill("Uppercut", BasicSkillType.STRIKE, 60, 0.5f, new Vector2(0, 0), "Punch upwards from below.\nPress E as Mark to execute.", Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/uppercut icon"));
    public static GeneralSkill markSkillSlot4 = new PlayerArt("Shattering Tempest", 100, "Attack with a barrage of punches.\nPress A as Mark to execute.", null, Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/shattering tempest icon"), TestM());
    public static GeneralSkill markSkillSlot5;
    public static GeneralSkill markSkillSlot6;

    public static GeneralSkill lunaSkillSlot1 = new PlayerBasicSkill("Plasma Cutter", BasicSkillType.SLASH, 60, 0.5f, new Vector2(0, 0), "Slash forward with a plasma blade.\nPress Q as Luna to execute.", Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/plasma cutter icon"));
    public static GeneralSkill lunaSkillSlot2 = new PlayerBasicSkill("Plasma Shot", BasicSkillType.BLAST, 30, 1f, new Vector2(-3000f, 0), "Shoot a small plasma burst forward.\nPress W as Luna to execute.", Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/plasma shot icon"));
    public static GeneralSkill lunaSkillSlot3 = new PlayerBasicSkill("Backflip", BasicSkillType.MOVEMENT, 60, 1f, new Vector2(-12000f, 0), "Flip backwards. Grants brief invulnerability.\nPress E as Luna to execute.", Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/backflip icon"));
    public static GeneralSkill lunaSkillSlot4 = new PlayerArt("Fissure Rush", 100, "Dash forwards, cleaving everything in your way.\nPress A as Luna to execute.", null, Resources.Load<Sprite>("Graphics/UI/Pause Menu/Skills/fissure rush icon"), TestL());
    public static GeneralSkill lunaSkillSlot5;
    public static GeneralSkill lunaSkillSlot6;
}