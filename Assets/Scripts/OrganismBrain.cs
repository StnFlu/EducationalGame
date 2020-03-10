﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrganismBrain : MonoBehaviour
{
    private bool CurPlayer;

    public NavMeshAgent player;

    public int age;

    public bool Gender;

    public int health;
    public int hunger;
    public bool horny = true;

    public Transform target;
    public Rigidbody rb;
    private GameManager gm;
    public GameObject Poop;
    public GameObject Child;
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
    bool pooTime = true;
    public List<GameObject> breds;
    bool PoppTick = false;

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

        Gender = (Random.value > 0.5f);

        if (gm.CurrentPlayer == gameObject)
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

        //PooTime
        Excrete();

        //Breed
        Reproduce();
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

        if(hunger >30 &&seconds % 6 == 0 && pooTime)
        {
            Excrete();
        }
        else if (seconds % 6 == 0 && !pooTime)
        {
            if(!(seconds % 6 == 0))
            {
                pooTime = true;
            }
        }


    }
    // Update is called once per frame

    void FixedUpdate()
    {
        
        if (!hungry)
        {
            transform.LookAt(target);
            move(target.position);
        }
        else
        {
            if (food != null)
            {
                transform.LookAt(food);
                move(food.position);
            }
            else
            {
                transform.LookAt(target);
                move(target.position);
            }
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
    void Reproduce()
    {
        if(horny&& breds.Count>1)
        {
            int giveBirth = Random.Range(0, 10);
            if (giveBirth > 8)
            {
                horny = false;
                Instantiate(Child, transform.position, transform.rotation);
                
            }
        }
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

    public void Excrete()
    {
        

       
        if (seconds % 12 == 0 )
        {
            if (!PoppTick)
            {
                int poop = Random.Range(0, 100);
                if (poop > 90)
                {
                    Instantiate(Poop, transform.position, transform.rotation);
                }
            }
            PoppTick = true;
        }
        else
            PoppTick = false;


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
    void OnTriggerStay(Collider other)
    {

        if (horny && other.tag == "Player")
        {
            breds.Add(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {

    
            breds.Remove(other.gameObject);
        
    }
}
