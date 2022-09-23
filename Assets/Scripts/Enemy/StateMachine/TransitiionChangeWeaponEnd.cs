using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitiionChangeWeaponEnd : Transition
{
    [SerializeField] private float _delay;

    private float _timeAnimation;

    public override IEnumerator TransitionWork()
    {
        Debug.Log("1");

        while (true)
        {
            if (_timeAnimation > _delay)
            {
                NeedTransit = true;


                Debug.Log("2");
            }

            

            _timeAnimation += Time.deltaTime;

            Debug.Log("3");

            yield return null;
        }        
    }
}
