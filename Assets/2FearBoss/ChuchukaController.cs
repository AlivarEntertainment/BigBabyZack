using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuchukaController : MonoBehaviour
{
    public Transform[] ChuchukaPoints;
    public Quaternion[] direction;
    public int NextPoint = 0;
    public float speed;

    public void FixedUpdate()
    {   
        if(this.transform.position == ChuchukaPoints[NextPoint].position)
        {
            NextPoint += 1;
        }
        //float step = speed * Time.deltaTime;
        float step = speed * Time.deltaTime;
        //float RotationStep = speed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(this.transform.rotation, direction[NextPoint], step/2);
        transform.position = Vector3.MoveTowards(transform.position, ChuchukaPoints[NextPoint].position, step);
    }
}
