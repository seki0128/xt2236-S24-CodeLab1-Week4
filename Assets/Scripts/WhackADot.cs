using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WhackADot : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Whack a dot!");
        Vector3 newPos = new Vector3(Random.Range(-10,10),Random.Range(-5,5),0);
        transform.position = newPos;
        GameManager.instance.score++;
    }
}
