using UnityEngine;
using UnityEngine.Rendering.Universal; // Corrected namespace

[RequireComponent(typeof(Light2D))] // Corrected attribute name
public class Flashlight : MonoBehaviour // Corrected class name
{
    private Light2D light2D; // Corrected variable name

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>(); // Corrected method name
        light2D.enabled = false; // Corrected property name and added semicolon
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) // Corrected parameter type
    {
     if (collision.CompareTag("dark"))
        {
            light2D.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // Corrected parameter type and method name
    {
        if (collision.CompareTag("dark"))
        {
            light2D.enabled = false;
        }
    }
}
