using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private float startWaitTime;
    

    public Transform[] movePos;

    private int i = 1;
    private bool movingRight = true;
    private float waitTime;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (movingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }

                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
    }
    
}
