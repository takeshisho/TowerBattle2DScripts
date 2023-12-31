using UnityEngine;

public class MobMove : MonoBehaviour
{
    public void Move(float speed, int forwardDirection) 
    {
        transform.position += new Vector3(forwardDirection, 0, 0) * Time.deltaTime * speed;
    }

}
