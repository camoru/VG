using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class portal : MonoBehaviour
{
    public GameObject target;
    public GameObject targetMap;
    
    bool start = false;
    bool isFadeIn = false;
    float alpha = 0;
    float FadeTime = 1f;

    
    GameObject area;

    void Awake(){
	Assert.IsNotNull(target);
	GetComponent<SpriteRenderer>().enabled = false;
	transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
	Assert.IsNotNull(targetMap);
	area = GameObject.FindGameObjectWithTag("cuadro_titulo");
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
	other.GetComponent<Animator>().enabled = false;
	other.GetComponent<Evillion>().enabled = false;
	FadeIn();
	yield return new WaitForSeconds(FadeTime);

	//other.transform.position = target.transform.GetChild(0).transform.position;

	if(other.tag == "Evillion")
	{
		other.transform.position =  target.transform.GetChild(0).transform.position;
		Camera.main.GetComponent<main_camera>().SetBound(targetMap);
		Camera.main.GetComponent<main_camera>().FastMove();
	}
	FadeOut();
	other.GetComponent<Animator>().enabled = true;
	other.GetComponent<Evillion>().enabled = true;
	
	StartCoroutine(area.GetComponent<cuadro_titulo>().ShowArea(targetMap.name));
    }
    void OnGUI()
    {
	if(!start)
	   return;
	GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

	Texture2D textu;
	textu = new Texture2D(1,1);
	textu.SetPixel(0,0,Color.black);
	textu.Apply();
	
	GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textu);

	if(isFadeIn)
	{
		alpha = Mathf.Lerp(alpha, 1.1f, FadeTime * Time.deltaTime);
	}else{
		alpha = Mathf.Lerp(alpha, -0.1f, FadeTime * Time.deltaTime);
		if(alpha < 0) start = false;	
	}
    }
    void FadeIn()
    {
	start = true;
	isFadeIn = true;
    }
    void FadeOut()
    {
	isFadeIn = false;
    }
}
