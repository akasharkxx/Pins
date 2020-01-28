using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 50f;

    private bool canRotate;

    private float angle;
    void Awake()
    {
        canRotate = true;
        StartCoroutine (ChangeRotation());
    }

    IEnumerator ChangeRotation(){
        yield return new WaitForSeconds(Random.Range(2f,4f));

        // rotationSpeed = Random.Range(50, 100);
        // rotationSpeed *= -1;
        if(Random.Range(0,2) > 0){
            rotationSpeed = -Random.Range(50, 100);
        }else{
            rotationSpeed = Random.Range(50,100);
        }

        StartCoroutine(ChangeRotation());
    }
    // Update is called once per frame
    void Update()
    {
        if(canRotate){
            RotateCircle();
        }    
    }

    void RotateCircle(){
        angle = transform.rotation.eulerAngles.z;
        angle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle));
    }
}
