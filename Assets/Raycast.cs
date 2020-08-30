using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    Renderer render;
    GameObject last; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (render != null)
            {
                render.material.shader = Shader.Find("Diffuse");
            }

            last = hit.transform.gameObject;
            render = last.GetComponent<Renderer>();
            render.material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
            //  Debug.Log("Did Hit" + hit.transform.gameObject.name);


           
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            // Debug.Log("Did not Hit");
            
        }
    }
}

