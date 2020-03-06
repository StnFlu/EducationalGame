using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduction : MonoBehaviour
{

    public GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void reproduce(GameObject current,  GameObject target)
    {
        List<GameObject> gameObjects = null;
        gameObjects.Add(current);
        gameObjects.Add(target);
        Instantiate(child, (current.transform.position - target.transform.position), current.transform.rotation);
    }
}
