using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILMonoBehaviour : MonoBehaviour
{
    public  Action OnUpdate;
    public  Action OnLateUpdate;
  

    void Update()
    {
        OnUpdate?.Invoke();
    }

    private void LateUpdate()
    {
        OnLateUpdate?.Invoke();
    }

    /*
    public Action<GameObject, Collider> EnterTrigger;
    public Action<GameObject, Collider> StayTrigger;
    public Action<GameObject, Collider> ExitTrigger;

    public Action<GameObject, Collision> EnterCollision;
    public Action<GameObject, Collision> StayCollision;
    public Action<GameObject, Collision> ExitCollision;
    private void OnTriggerEnter(Collider other)
    {
        EnterTrigger?.Invoke(this.gameObject, other);
    }

    private void OnTriggerStay(Collider other)
    {
        StayTrigger(this.gameObject, other);
    }


    private void OnTriggerExit(Collider other)
    {
        ExitTrigger?.Invoke(this.gameObject,other);
    }


    private void OnCollisionEnter(Collision collision)
    {
        EnterCollision(this.gameObject, collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        StayCollision(this.gameObject,collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        ExitCollision(this.gameObject, collision);
    }
     */

}
