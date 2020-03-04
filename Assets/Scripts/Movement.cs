using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
<<<<<<< Updated upstream
    //This will be the first movement system and will be the simplest algorithm that merely follows the target or food object.
    void Move(Transform x)
    {

=======
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    //Points the object towards a position and moves it fowards.
    public void BasicMove(Transform targetPosition)
    {
        transform.LookAt(targetPosition);
        rb.velocity = rb.transform.forward;
>>>>>>> Stashed changes
    }
}
