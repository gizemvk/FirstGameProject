using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform target; // Takip edilecek nesnenin referans�
    public float followSpeed = 5f; // Kameran�n takip h�z�
    public float rotationSpeed = 5f; // Kameran�n d�n�� h�z�

    private Vector3 offset; // Kamera ile nesne aras�ndaki mesafe
    private Vector3 initialPosition; // Kameran�n ba�lang�� konumu
    private Quaternion initialRotation; // Kameran�n ba�lang�� rotasyonu

    void Start()
    {
        // Kamera ile nesne aras�ndaki ba�lang�� mesafesini hesapla
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

  










