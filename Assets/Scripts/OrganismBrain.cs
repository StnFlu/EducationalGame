using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismBrain : MonoBehaviour
{
    public int age;

    public int health;
    public int hunger;

    public Transform target;
    public Rigidbody rb;
    private GameManager gm;
    public Transform food;

    bool hungerTick;
    bool healthTick;
    bool ageTick;

    float clock = 0;
    public int seconds;

    //modifiers
    public float movespeed;

    public Color start;
    public Color end;
    public bool hungry;
    public bool eating;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        //set movespeed to rand range
        movespeed = Random.Range(0.4f, 0.9f);
        age = Random.Range(0, 25);
    }

    private void Update()
    {
        //statmanagement
        clock += Time.deltaTime;
        seconds = (int)clock;

        //age
        aging();

        //hungryManagment
        gethungry();
        if (hunger <= 80 || eating)
        {
            hungry = true;
        }
        else
        {
            food = null;
            hungry = false;
        }
        if (hunger > 100)
        {
            hunger = 100;
            eating = false;
        }
        //lose health when starving
        loseHealth();
        //changecolour based on health
        transform.GetComponentInChildren<Renderer>().material.color = Color.Lerp(start,end,(float)health/100);
        //find nearest food
        food = findNearestFood();


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //aging
        
       // health -= Time.deltaTime / 2;
        //transform.localScale = new Vector3(health / 100, health / 100, health / 100);


        //movement
        if (!hungry)
        {
            move(target);
        }
        else
        {
            if (food != null)
            {
                move(food);
            }
            if (food == null)
            {
                move(target);
            }
        }
    }
    void move(Transform targetPos)
    {
        transform.LookAt(targetPos);
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
    public int increment(int current, int difference)
    { 
        return current += difference;
    }
    void aging()
    {
        if (seconds % 12 == 0)
        {
            if (!ageTick)
                age = increment(age, 1);
            ageTick = true;
        }
        else
            ageTick = false;
    }
    void gethungry()
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
    void loseHealth()
    {
       
        if (seconds % 4 == 0)
        {
            if (!healthTick)
                health = increment(health, -1);
            healthTick = true;
        }
        else
            healthTick = false;
    }
   
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "food" && hungry)
        {
            eating = true;
            hunger ++;
            collision.gameObject.GetComponentInParent<food>().foodAmount--;
        }
    }
}
