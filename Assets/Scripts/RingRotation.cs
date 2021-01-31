using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotation : MonoBehaviour
{
    //public float rotateStartTime;
    //private float rotateTime;

    public float rotateSpeed;
    public int clock;

    private Quaternion targetRotation;

    //public bool autoRotate;

    // Start is called before the first frame update
    void Start()
    {
        //rotateTime = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);
    }
    private void FixedUpdate()
    {
        //if (rotateTime >= 0)
        //{
        //    rotateTime -= Time.deltaTime;
        //}
        //else if(autoRotate)
        //{
        //    ClockWise(clock);
        //    //transform.localEulerAngles = new Vector3(0, 0, transform.rotation.z + 45);
        //    rotateTime = rotateStartTime;
        //}
    }
    public void ClockWise()
    {
        targetRotation = Quaternion.Euler(0.0f, 0.0f, transform.rotation.eulerAngles.z - clock * 45.0f);
    }

}
