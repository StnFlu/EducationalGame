using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismBrain : MonoBehaviour
{
    protected int age;

    protected int health;
    protected int hunger;

    public Transform target;
    public Rigidbody rb;
    protected GameManager gm;
    public Transform food;
    protected Transform org;

    protected bool hungerTick;
    protected bool healthTick;
    protected bool ageTick;

    float clock = 0;
    public int seconds;

    //modifiers
    public float movespeed;

    public Color start;
    public Color end;
    public bool hungry;
    public bool eating;

    protected Movement m = new Movement();
    protected Sensitivity s = new Sensitivity();
    protected Growth g = new Growth();
    protected Nutrition n = new Nutrition();


    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        org = gameObject.transform;
        movespeed = 4f;
        age = Random.Range(0, 25);
    }

    private void Update()
    {
        //statmanagement
        clock += Time.deltaTime;
        seconds = (int)clock;

        //age
        g.aging();

        //hungryManagment
        n.gethungry();
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
        g.loseHealth();
        //changecolour based on health
        transform.GetComponentInChildren<Renderer>().material.color = Color.Lerp(start,end,(float)health/100);
        //find nearest food
        food = s.findNearestFood();


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hungry)
        {
            m.move(target);
        }
        else
        {
            if (food != null)
            {
                m.move(food);
            }
            if (food == null)
            {
                m.move(target);
            }
        }
        g.scale();
    }
   
    public int increment(int current, int difference)
    { 
        return current += difference;
    }
    public float increment(float current, float difference)
    {
        return current += difference;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "food" && hungry)
        {
            eating = true;
            hunger++;
            collision.gameObject.GetComponentInParent<food>().foodAmount--;
        }
    }
}
