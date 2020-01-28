using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private Button shootButton;

    [SerializeField]
    private GameObject needle;

    private GameObject[] gameNeedles;

    [SerializeField]
    private int howManyNeedles;
    private float needldist = 0f; 
    private int needleIndex;

    void Awake()
    {
        if(instance == null){
            instance = this;        //GameManager
        }    
        GetBtn();
    }

    // Update is called once per frame
    void Start()
    {
        CreateNeds();
    }

    //Easier way than this to get onCLick    
    void GetBtn(){
        shootButton = GameObject.Find("Shoot Button").GetComponent<Button> ();
        shootButton.onClick.AddListener (() => ShootNed());
    }

    public void ShootNed(){
        gameNeedles [needleIndex].GetComponent<NeedleMovement>().FireNeedle();
        needleIndex++;
        if(needleIndex == gameNeedles.Length){
            Debug.Log("finished");
            shootButton.onClick.RemoveAllListeners();
        }
    }

    void CreateNeds(){
        gameNeedles = new GameObject[howManyNeedles];
        Vector3 temp = transform.position;

        for(int i = 0; i < gameNeedles.Length; i++){
            gameNeedles[i] = Instantiate(needle, temp, Quaternion.identity);
            temp.y -= needldist;
        }
    }

    public void InstantiateNeedle(){
        Instantiate(needle, transform.position, Quaternion.identity);
    }
}
