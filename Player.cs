using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction ChangingHealthEvent;

    public float Health { get; private set; }

    private float _damage = 10f;
    private float _heal = 10f;
    private float _maxHealth = 100;

    private void OnEnable()
    {
        Health = _maxHealth;
    }

    public void TakeHealth()
    {
        Health += _heal;

        if (Health > _maxHealth)
        {
            Health = _maxHealth;
        }

        ChangingHealthEvent?.Invoke();

        Debug.Log("Cured");
    }

    public void TakeDamaage()
    {
        Health -= _damage;

        if (Health < 0)
        {
            Health = 0;
        }

        ChangingHealthEvent?.Invoke();

        Debug.Log("Damaged");
    }
}