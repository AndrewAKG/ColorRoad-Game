using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offsetPosition;
    private Vector3 moveVector;
    private Vector3 conditionalVector = new Vector3(0f, 1f, 1f);

    //private float transition = 0.0f;
    //private float animationDuration = 3.0f;
    //private Vector3 animationOffset = new Vector3(0, 5, 5);

    private void Awake()
    {
        offsetPosition = transform.position - target.position;    
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Scale(transform.position, conditionalVector);
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);
            return;
        }

        moveVector = target.position + offsetPosition;
        //X
        moveVector.x = 0;

        //if(transition > 1.0f)
        //{
        transform.position = moveVector;
        //}
        //else
        //{
        //    transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
        //    transition += Time.deltaTime * 1 / animationDuration;
        //    transform.LookAt(target.position + Vector3.up);
        //}
    }
}
