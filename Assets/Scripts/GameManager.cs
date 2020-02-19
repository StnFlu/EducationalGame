using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> Food;
    public GameObject organisms;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnOrganisms();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addFood(GameObject x)
    {
        Food.Add(x.transform);
    }
    void spawnOrganisms()
    {
        int number = Random.Range(10, 25);
        for (int i = 0 ; i < number; i++)
        {
            Instantiate(organisms, new Vector3(2, 0, 2), transform.rotation, GameObject.Find("Organisms").transform);
        }
    }
    public void removeFood(GameObject x)
    {
        Food.Remove(x.transform);
    }
    public void setTimeScale(float newtimeScale)
    {
        Time.timeScale = newtimeScale;
    }
}
