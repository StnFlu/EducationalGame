using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : OrganismBrain
{
    public void move(Transform targetPos)
    {
        transform.LookAt(targetPos);
        rb.velocity = rb.transform.forward * movespeed;
    }

}
