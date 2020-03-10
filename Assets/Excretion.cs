using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excretion : OrganismBrain
{
    public void des()
    {
        gm.inst(gameObject, gameObject.transform);
    }
}
