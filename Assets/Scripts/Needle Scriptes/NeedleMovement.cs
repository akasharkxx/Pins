using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject needleBody;

    private bool canFCircle = false;            //Fire
    private bool TCircle = false;            //Touch
    
    public float forceY = 40f;

    private Rigidbody2D myBody;

    void Awake(){
        //speed = 100f;
        Initialize ();
        //FireNeedle ();
    }

    void Initialize(){
        needleBody.SetActive(false);
        myBody = GetComponent<Rigidbody2D> ();

    }

    void Update(){
        if(canFCircle){
            myBody.velocity = new Vector2(0, forceY); 
        }
    }

    public void FireNeedle(){
        needleBody.SetActive(true);
        myBody.isKinematic = false;
        canFCircle = true;
    }

    void OnTriggerEnter2D(Collider2D target){
        //Debug.Log("trigger");
        if(TCircle){
            //Debug.Log("trigger1");
            return;
        }
        
        if(target.tag == "Circle"){
            //Debug.Log("trigger2");
            canFCircle = false;
            TCircle = true;
            myBody.isKinematic = true;
            myBody.velocity = new Vector2(0, 0);

            gameObject.transform.SetParent(target.transform);

            if(ScoreManager.instance != null){
                ScoreManager.instance.SetScore();
            }
            // if(GameManager.instance != null){
            //     GameManager.instance.InstantiateNeedle();
            // }
        }
    }
}
