using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;



public class Rewind : MonoBehaviour
{
    public int limite;
    public int id;

    public bool isRewinding = false;
    public bool isForwarding = false;
    public bool isRecording = true;
    public bool bulletime;
    public int recordTime = 0;

    public List<PointInTime> pointsInTime;
    Rigidbody rb;
    NavMeshAgent nma;

   




    void Start()
    {
        bulletime = false;
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
        nma = GetComponent<NavMeshAgent>();

        


    }


    void Update()
    {
        if(recordTime < 0)
        {
            recordTime = 0;
        }
        else if(recordTime > limite)
        {
            recordTime = limite;
        }
        Debug.Log(pointsInTime.Count);
        if (bulletime == true)
        {

            if (Input.GetKeyDown(KeyCode.R))//start rewinding
            {
                StartRewinding();
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                StopRewinding();
            }
            if (Input.GetKeyDown(KeyCode.F)) //start moving forward
            {
                StartForward();
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                StopForward();
            }
        }
        if (Input.GetKeyDown(KeyCode.Y)) //enter and leave pause mode
        {
            if (bulletime == false)
            {
                recordTime = 0;
                bulletime = true;
                isRecording = false;
                rb.isKinematic = true;
                if (GetComponent<NavMeshAgent>() != null)
                {
                    nma.speed = 0f;
                }


            }
            else if (bulletime == true)
            {
                bulletime = false;
                isRecording = true;
                rb.isKinematic = false;
                if (GetComponent<NavMeshAgent>() != null)
                {
                    nma.speed = 3.5f;
                }

                rb.velocity = pointsInTime[recordTime].velocity;
                rb.angularVelocity = pointsInTime[recordTime].AngularVelocity;

                pointsInTime.RemoveAll(x => x != null);

                Debug.Log(pointsInTime.Count);

            }

        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            ReWind();
        }

        else if (isForwarding)
        {
            FastForward();
        }
        else if (isRecording)
        {

            Record();
        }
        


       



    }

    void ReWind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime point = pointsInTime[recordTime];
            
            transform.position = point.position;
            transform.rotation = point.rotation;

            recordTime++;

            if (recordTime >= pointsInTime.Count)
            {
                Debug.Log("Bullshit");
                recordTime = pointsInTime.Count - 1;
                pointsInTime.RemoveAt(0);

            }
               

        }
        else
        {
            StopRewinding();
        }

    }

    void FastForward()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime point = pointsInTime[recordTime - 1];
            
            transform.position = point.position;
            transform.rotation = point.rotation;


            recordTime--;
            

        }
        else
        {
            StopRewinding();
        }

    }

    void Record()
    {
        if (pointsInTime.Count >= limite)
            pointsInTime.RemoveAt(pointsInTime.Count - 1);


        pointsInTime.Insert(0, new PointInTime(transform.position, rb.velocity, rb.angularVelocity, transform.rotation));
    }

    void StartRewinding()
    {

        isRewinding = true;
    }

    void StopRewinding()
    {
        isRewinding = false;
    }

    void StartForward()
    {
        isForwarding = true;
    }

    void StopForward()
    {
        isForwarding = false;
    }
}
