using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicEnemy : MonoBehaviour
{
    public Life _life;
    public int _maxlife = 10;
    public TMP_Text _lifeText;

    private void Awake()
    {
        _life = new Life(_maxlife);
        _lifeText.text = _life.Health.ToString();
    }

    public void TakeDamege(int damageDeal) 
    {
        _life.Damage(damageDeal);
        if (_life.Health <= 0){Destroy(gameObject);}
        updateCanva();
    }

    private void updateCanva()
    {
        _lifeText.text = _life.Health.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        TakeDamege(5);
    }
}
