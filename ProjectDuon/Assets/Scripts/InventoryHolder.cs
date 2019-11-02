using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryHolder {

    public static List<Cookie> cookies = new List<Cookie>();
    public static List<IceCream> iceCreams = new List<IceCream>();
    public static List<TripleSandwich> sandwiches = new List<TripleSandwich>();
    public static List<LilithsChickenSoup> soups = new List<LilithsChickenSoup>();
    public static List<EnergyDrink> energyDrinks = new List<EnergyDrink>();
    public static List<Painkiller> painkillers = new List<Painkiller>();
    public static List<ChamomileTea> teas = new List<ChamomileTea>();
    public static List<BlastingUnit> blastingUnits = new List<BlastingUnit>();

    public static void AddItems()
    {
        cookies.Clear();
        iceCreams.Clear();
        sandwiches.Clear();
        soups.Clear();
        energyDrinks.Clear();
        painkillers.Clear();
        teas.Clear();
        blastingUnits.Clear();

        cookies.Add(new Cookie());
        cookies.Add(new Cookie());
        cookies.Add(new Cookie());

        iceCreams.Add(new IceCream());
        iceCreams.Add(new IceCream());

        sandwiches.Add(new TripleSandwich());
        sandwiches.Add(new TripleSandwich());

        soups.Add(new LilithsChickenSoup());
        /*
        energyDrinks.Add(new EnergyDrink());

        painkillers.Add(new Painkiller());

        teas.Add(new ChamomileTea());

        blastingUnits.Add(new BlastingUnit());*/
    }

}
