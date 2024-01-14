using UnityEngine;

public class HitPoint : MonoBehaviour
{
    public int Hp;
    private bool isDead;

    protected virtual void Start() {
        isDead = false;
    }

    public virtual void Damage(int damage)
    {
        Hp -= damage;
        if(Hp < 0) Hp = 0;
        if (Hp <= 0 && !isDead)
        {
            Hp = 0;
            isDead = true;
            OnDie();
        }
    }

    protected virtual void OnDie()
    {
        Destroy(gameObject);
    }

}
