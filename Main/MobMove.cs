using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobMove : MobManager
{
    const int RIGHT = 1;
    const int LEFT = -1;
    private int forwardDirection = LEFT;
    private bool isMoveable = true;

    private void Start()
    {
        if (IsEnemy) forwardDirection = RIGHT;
    }

    private void Update() {
        if(isMoveable) Move();
        
    }

    private void Move() {
        transform.position += new Vector3(forwardDirection, 0, 0) * Time.deltaTime * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" && this.gameObject.tag == "Player"
            || other.gameObject.tag == "Player" && this.gameObject.tag == "Enemy") 
        {
            isMoveable = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" && this.gameObject.tag == "Player"
            || other.gameObject.tag == "Player" && this.gameObject.tag == "Enemy") 
        {
            isMoveable = true;
        }
    }
}
