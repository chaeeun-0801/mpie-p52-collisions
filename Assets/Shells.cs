using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shells : MonoBehaviour
{
    public float ammoLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//edit-> project setting -> Fire1 (when left mouse clikced)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f)); //ray : a line to the red dot (the reason why it's 0.5f : middle of the screen)
            RaycastHit result;
            bool hit = Physics.Raycast(ray, out result);//Raycast function has 3 parameters (character position, ray goes forward, and tell what object collides)

            if(result.collider.gameObject.name == "Target")//if we hit the "Target" object (lecture 5.2 slide 31)
            {
                GameObject g = result.collider.gameObject;
                Animation a = g.transform.parent.GetComponent<Animation>();
                a.Play("LowerBridge");
            }
        }
        
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.name == "AmmoBox")
       
            other.gameObject.SetActive(false);
            ammoLevel = 20;
        
    }
}
