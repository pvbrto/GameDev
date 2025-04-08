using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private float startWaitTime;
    private float waitTime;

    [SerializeField] private Transform movePos;
    [SerializeField] private Transform BottomLeftPos;
    [SerializeField] private Transform TopRightPos;


    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos.position = new Vector2(Random.Range(BottomLeftPos.position.x, TopRightPos.position.x), Random.Range(BottomLeftPos.position.y, TopRightPos.position.y));
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = new Vector2(Random.Range(BottomLeftPos.position.x, TopRightPos.position.x), Random.Range(BottomLeftPos.position.y, TopRightPos.position.y));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

}
