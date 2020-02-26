using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrganismBrain : MonoBehaviour
{
    private bool CurPlayer;

    public NavMeshAgent player;

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
    public bool defaultMovement = true;
    float clock = 0;
    public int seconds;

    //modifiers
    public float movespeed;

    public Color start;
    public Color end;
    public Color start1;
    public Color end1;
    public bool hungry;
    public bool eating;

    void Start()
    {
        player.Warp(transform.position);
        target = GameObject.Find("Target").transform;
        gm = FindObjectOfType<GameManager>();
        //set movespeed to rand range
        movespeed = Random.Range(0.4f, 0.9f);
        age = Random.Range(0, 12);
        defaultMovement = true;
        player.speed = movespeed;


        if(gm.CurrentPlayer == gameObject)
        {
            CurPlayer = true;
        }
    }
   
    public void move(Vector3 pos)
    {
        player.SetDestination(pos);
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
        if (!CurPlayer)
        {
            transform.GetComponentInChildren<Renderer>().material.color = Color.Lerp(start, end, (float)health / 100);
        }
        else
        {
            transform.GetComponentInChildren<Renderer>().material.color = Color.Lerp(start1, end1, (float)health / 100);
        }
            //find nearest food
        food = findNearestFood();


    }
    // Update is called once per frame

    void FixedUpdate()
    {
        if (!hungry)
        {
            move(target.position);
        }
        else
        {
            if (food != null)
            {
                move(food.position);
            }
            else
                move(target.position);
        }
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
            {
                age = increment(age, 1);
                Growth(age);
            }
                ageTick = true;
        }
        else
            ageTick = false;
    }
    void Growth(int age)
    {
        if(age< 18)
        {
            transform.localScale = transform.localScale * 1.1f;
        }
        else if(age > 18 && age < 30)
        {

        }
        else
        {
            transform.localScale = transform.localScale * 0.95f;
        }
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
    public void AddDamage()
    {
        Debug.Log("test");
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
