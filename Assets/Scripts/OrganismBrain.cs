using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismBrain : MonoBehaviour
{
    public int age;

    public float health;
    public int hunger;
    public Transform target;
    public Rigidbody rb;
    private GameManager gm;
    public Transform food;
    private float hungerTime = 2f;

    //modifiers
    public float movespeed;
   

    public bool hungry;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        movespeed = Random.Range(0.4f, 0.9f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //aging
        health -= Time.deltaTime / 2;
        transform.localScale = new Vector3(health / 100, health / 100, health / 100);
        //movement
        if (!hungry)
        {
            transform.LookAt(target);
            move();
        }
        //Hunger
        
        if(hungerTime<= 0)
        {
            hunger--;
            hungerTime = 2f;
        }
        else
        {
            hungerTime -= Time.deltaTime;
        }
        if (hunger <= 80)
        {
            if (!food)
                findNearestFood();
            hungry = true;
            food = findNearestFood();
            
            transform.LookAt(food);
            if (food = null)
            { transform.LookAt(target); }
            move();
        }
        else
        {
            food = null;
            hungry = false;
        }

        if (hunger > 100)
            hunger = 100;

    }
    void move()
    {
        rb.velocity = rb.transform.forward * movespeed;
    }
    public Transform findNearestFood()
    {
        Transform foodClosest = null;
        float closestFood = Mathf.Infinity;
        foreach (Transform foodItem in gm.Food)
        {

            float distance = Vector3.Distance(transform.position, foodItem.transform.position);
            if(distance < closestFood)
            {
                foodClosest = foodItem;
                closestFood = distance;
            }
        }
        return foodClosest;
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "food" && hungry)
        {
            hunger ++;
            collision.gameObject.GetComponentInParent<food>().foodAmount--;
        }
    }
}
