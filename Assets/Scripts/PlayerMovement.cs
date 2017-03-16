using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float waitBuffer = 1f;

    private bool bufferBool;
    void Update ()
    {
        if (Input.GetKey(KeyCode.W) && !bufferBool)
        {
            transform.position += Vector3.left;
            StartCoroutine(WaitBeforeMove());
        }
        if (Input.GetKey(KeyCode.S) && !bufferBool)
        {
            transform.position += Vector3.right;
            StartCoroutine(WaitBeforeMove());
        }
        if (Input.GetKey(KeyCode.A) && !bufferBool)
        {
            transform.position += Vector3.back;
            StartCoroutine(WaitBeforeMove());
        }
        if (Input.GetKey(KeyCode.D) && !bufferBool)
        {
            transform.position += Vector3.forward;
            StartCoroutine(WaitBeforeMove());
        }
        //WaitBeforeMove();
    }

    //void WaitBeforeMove()
    //{
    //    if (waitBuffer > 0)
    //    {
    //        waitBuffer -= Time.deltaTime;
    //        bufferBool = true;
    //    }
    //    else
    //    {
    //        waitBuffer = 0;
    //        bufferBool = false;
    //    }
    //}

    IEnumerator WaitBeforeMove()
    {
        bufferBool = true;
        yield return new WaitForSeconds(waitBuffer);
        bufferBool = false;
    }
}
