using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class limite_mapa : MonoBehaviour
{
    public GameObject mapaActual;
    public GameObject mapaDestino;
    GameObject accesoEvillion;
    void Awake()
    {
	Assert.IsNotNull(mapaActual);
	GetComponent<SpriteRenderer>().enabled = false;
	Assert.IsNotNull(mapaDestino);
    }
    void OnTriggerEnter2D (Collider2D other)
    {
	if(other.tag == "Evillion")
	{
		/*Camera.main.GetComponent<main_camera>().FastMove();	*/
		Camera.main.GetComponent<main_camera>().SetBound(mapaDestino);	
		mapaActual = mapaDestino;
		/*mapaDestino = GetComponent<Evillion>().actualMap;*/
		accesoEvillion = GameObject.FindGameObjectWithTag("Evillion");
		mapaDestino = accesoEvillion.GetComponent<Evillion>().actualMap;
		/*StartCoroutine(*/accesoEvillion.GetComponent<Evillion>().cambioDMapa(mapaActual);

	}
    }
}
