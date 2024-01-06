using UnityEngine;

public class HitPoint : MonoBehaviour
{
    public int Hp;

    protected virtual void Start() {
    }

    public virtual void Damage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            OnDie();
        }
    }

    protected virtual void OnDie()
    {
        Destroy(gameObject);
    }

}
