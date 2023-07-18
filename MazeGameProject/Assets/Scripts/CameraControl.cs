using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform target; // Takip edilecek nesnenin referansý
    public float followSpeed = 5f; // Kameranýn takip hýzý
    public float rotationSpeed = 5f; // Kameranýn dönüþ hýzý

    private Vector3 offset; // Kamera ile nesne arasýndaki mesafe
    private Vector3 initialPosition; // Kameranýn baþlangýç konumu
    private Quaternion initialRotation; // Kameranýn baþlangýç rotasyonu

    void Start()
    {
        // Kamera ile nesne arasýndaki baþlangýç mesafesini hesapla
        offset = transform.position - target.transform.position;
      
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.LookRotation(target.transform.forward);
        transform.position = target.position + rotation * offset;

        float desiredAngle = target.eulerAngles.y;
       
        transform.position = target.transform.position + offset;

      

       
    }
}



















    ////public GameObject ball;
    ////public Vector3 dist;
    //public Transform ball;
    //private Vector3 dist;
    //public float sSpeed = 0.5f;

    ////public Transform lookTarget;

    //private void Start()
    //{
    //    dist = transform.position - ball.position;
    //}

    ////private void Update()
    ////{
    ////        transform.LookAt(dist);
    ////}
    //private void LateUpdate()
    //{
    //    float desiredAngle = ball.eulerAngles.y;
    //    Quaternion rotation = Quaternion.Euler(0f, desiredAngle, 0f);
    //    transform.position = ball.transform.position + dist;
    //}

    //private void FixedUpdate()
    //{
    //    Vector3 dPos = cameraTarget.position + distance;
    //    Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
    //    transform.position = sPos;
    //    transform.LookAt(lookTarget.position);
    //}

  










