using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobMove : MobManager
{
    const int RIGHT = 1;
    const int LEFT = -1;
    public int forwardDirection = LEFT;

    private void Start()
    {
        if (IsEnemy) forwardDirection = RIGHT;
    }

    private void Update() {
        transform.position += new Vector3(1f, 0, 0) * forwardDirection * Time.deltaTime * Speed;
    }
}
