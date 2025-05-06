using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected string _name;
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    protected int hp;
    public int HP
    {
        get => hp;
        set => hp = value;
    }

    private float speed;

    public void SetCharacter(string newName, int newHp)
    {
        Name = newName;
        HP = newHp;
        speed = 10f;
    }

    public int GetHp()
    {
        return HP;
    }

    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log($"------ {Name} HP Remaining : {HP} ");
        if (IsDead())
        {
            Debug.Log($"------ {Name} is dead");
        }
    }

    public bool IsDead()
    {
        return HP <= 0;
    }
}