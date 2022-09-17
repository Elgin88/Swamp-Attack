using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : State
{
    [SerializeField] private float _speed;

    public override void StartStateWork()
    {
        StartCoroutine(StateWork());
    }

    public override void StopStateWork()
    {
        StopCoroutine(StateWork());
    }

    public  IEnumerator StateWork()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
            yield return null;
        }        
    }
}
