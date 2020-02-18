using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectUnits : MonoBehaviour
{
    public LayerMask test;
    public Collider[] hitColliders;
    public Vector3 offset;
    public OrganismBrain OB;
    public float dist;
    public Transform one;
        public Transform two;
        public Transform three;
    public Transform right;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hiter;
        if (Physics.BoxCast(transform.position, transform.localScale, transform.forward, out hiter, transform.rotation, dist, test))
        {
            OB.defaultMovement = false;
            Debug.Log(hiter.collider.name);
            OB.move2(transform, Vector3.forward);
        }
        else
            OB.defaultMovement = true;

   


        //    RaycastHit hit;
        //RaycastHit hit2;
        //RaycastHit hit3;
        //RaycastHit hit4;
        //if (Physics.Raycast(one.position, transform.TransformDirection(Vector3.forward), out hit, dist) || Physics.Raycast(two.position, transform.TransformDirection(Vector3.forward), out hit, dist) || Physics.Raycast(three.position, transform.TransformDirection(Vector3.forward), out hit, dist))
        //{
        //    OB.defaultMovement = false;
        //    Debug.DrawRay(one.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //    Debug.DrawRay(two.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //    Debug.DrawRay(three.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //    Debug.Log("Something In Front");
        //    //move left or right

        //    OB.move2(transform, Vector3.forward);




        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit2, .5f))
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit2.distance, Color.yellow);
        //    Debug.Log("Something To Left");
        //}
        //else
        //{
        //  //  OB.move(OB.target, Vector3.left);
        //}
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit3, .5f))
        //{
        //    Debug.Log("Something To Right");
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit3.distance, Color.yellow);

        //}
        //else
        //{
        //    //OB.move(OB.target, Vector3.right);
        //}
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit4, .5f))
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit4.distance, Color.yellow);
        //    Debug.Log("Something Behind");
        //}
        //else
        //{
        //  //  OB.move(OB.target, Vector3.back);
        //}

        //}
        //else
        //{
        //    OB.defaultMovement = true;
        //}

        //hitColliders = Physics.OverlapSphere(transform.position, 1f, test);
        //   int i = 0;
        //   while (i < hitColliders.Length)
        //   {
        //       //gameObject.GetComponent<OrganismBrain>().target;
        //       i++;
        //   }
        //int i = 0;
        //if (hitColliders[i].transform.root != transform)
        //{
        //    while (i < hitColliders.Length)
        //    {

        //        Debug.Log(hitColliders[i].gameObject.name);
        //        i++;



        //    }
        //}
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position,1f);
    }
}
