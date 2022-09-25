using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitiionChangeWeaponEnd : Transition
{
    [SerializeField] private float _delay;

    private float _timeAnimation;

    public override IEnumerator TransitionWork()
    {
        while (true)
        {
            if (_timeAnimation > _delay)
            {
                NeedTransit = true;
            }            

            _timeAnimation += Time.deltaTime;
            
            yield return null;
        }        
    }
}
