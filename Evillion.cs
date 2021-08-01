using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class Evillion : MonoBehaviour
{
    public float speed = 4f;
    
    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;	
    
    public GameObject initialMap;
    public GameObject actualMap;

    void Awake(){
	Assert.IsNotNull(initialMap);
    }

    void Start()
    {
        anim = GetComponent<Animator>(); 
        rb2d = GetComponent<Rigidbody2D>();
	actualMap = initialMap;
	Camera.main.GetComponent<main_camera>().SetBound(initialMap);
	/*actualMap = initialMap;*/
    }
    void Update()
    {
    	mov = new Vector2(
		Input.GetAxisRaw("Horizontal"),
		Input.GetAxisRaw("Vertical")
	);  
	if(mov != Vector2.zero){
		anim.SetFloat("mov_x", mov.x);
		anim.SetFloat("mov_y", mov.y);
		anim.SetBool("transicion_mov", true);
	} else{
		anim.SetBool("transicion_mov", false);
	} 	
	
    }
    void FixedUpdate()
    {
    rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
    public void cambioDMapa(GameObject nuevoActualMap)
    {
	actualMap = nuevoActualMap;
    }
}
