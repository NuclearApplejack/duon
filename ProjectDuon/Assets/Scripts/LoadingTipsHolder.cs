using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadingTipsHolder {

    public static List<string> loadingTips = new List<string>();
    public static string currTip;

    public static void PopulateList()
    {
        
        loadingTips.Add("While using Arts, you are invulnerable.");
        loadingTips.Add("An Outmarrow's shield will start regenerating if left undamaged for some time.\nTheir health, however, cannot regenerate.");
        loadingTips.Add("You can use Dimensional Switches ANYTIME the indicator is lit.\nThis includes during skills, dialogue and even cutscenes!");
        loadingTips.Add("Mark's Shattering Tempest is easy to use, but\nLuna's Fissure Rush deals significantly more damage.");
        loadingTips.Add("Taking damage with either character will end your Combo.\nIt will also end if you spend too long without landing an attack.");
        loadingTips.Add("If you ever run out of Stamina while fighting,\nswitch dimensions and continue your Combo while it regenerates.");
        loadingTips.Add("Healing items can only be used on the character you are currently controlling.");
        loadingTips.Add("Aside from her trademark chicken soup, Lilith's cooking is... Below average.");
        loadingTips.Add("Be wary when eating candies near Antony. He has an unhealthy addiction.");
        loadingTips.Add("Mark has a thing for thighs. Don't let Luna know.");
        loadingTips.Add("It seems Antony and Lilith know each other, despite being from different dimensions.\nPerhaps they have some history together?");
        loadingTips.Add("Lesser Outmarrow can be pretty cute. Just don't try to pet one,\nit will likely attempt to rip your face off.");
        loadingTips.Add("Selecting the Quit option from the Pause Menu during a stage will send you back to the Laboratory.\nSelecting it while in the Lab will send you to the Title Screen.");
    }

    public static void GenerateNewTip()
    {
        string prevTip = currTip;

        do
        {
            currTip = loadingTips[Random.Range(0, loadingTips.Count)];
        }
        while (currTip == prevTip);
    }
}
