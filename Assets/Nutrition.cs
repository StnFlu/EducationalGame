using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrition : OrganismBrain
{
    public void gethungry()
    {
        if (seconds % 4 == 0)
        {
            if (!hungerTick)
                hunger = increment(hunger, -1);
            hungerTick = true;
        }
        else
            hungerTick = false;
    }

   
}
