using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : OrganismBrain
{
    public void aging()
    {
        if (seconds % 12 == 0)
        {
            if (!ageTick)
                age = increment(age, 1);
            movespeed = increment(movespeed, -1);
            ageTick = true;
        }
        else
            ageTick = false;
    }
    public void loseHealth()
    {

        if (seconds % 4 == 0)
        {
            if ((!healthTick) && (!hungerTick))
                health = increment(health, -1);
            healthTick = true;
        }
        else
            healthTick = false;
    }
    public void scale()
    {
        if (age < 4)
        {
            org.localScale.Set(age, age, age);
        }
    }
}
