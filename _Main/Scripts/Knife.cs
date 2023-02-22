using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float RotationSpeed = 5;
    private void Update()
    {
    }
    internal void Rotate()
    {
        if (transform.Find("knife2").gameObject.activeInHierarchy)
            transform.Find("knife2").Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * RotationSpeed);


        if (transform.Find("model").gameObject.activeInHierarchy)
            transform.Find("model").Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * RotationSpeed);


        if (transform.Find("KnifeNew").gameObject.activeInHierarchy)
            transform.Find("KnifeNew").Rotate(new Vector3(0, -Input.GetAxis("Mouse Y"), 0) * Time.deltaTime * RotationSpeed);


        if(transform.Find("KnifeCPI2").gameObject.activeInHierarchy)
            transform.Find("KnifeCPI2").Rotate(new Vector3(0, -Input.GetAxis("Mouse Y"), 0) * Time.deltaTime * RotationSpeed);


        //if (transform.name == "knife2")
        //    transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * RotationSpeed);
        //if(transform.name == "model")
        //    transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * RotationSpeed);
        //if(transform.name == "KnifeNew" || transform.name == "KnifeCPI2")
        //    transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse Y"), 0) * Time.deltaTime * RotationSpeed);

        Vector2 touchDeltaPosition = Input.mousePosition; //Input.GetTouch(0).deltaPosition; 
        //transform.Rotate(0, -touchDeltaPosition.y * RotationSpeed, 0);
        //if (Input.touchCount > 0 &&
        //    Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //}
    }
}
