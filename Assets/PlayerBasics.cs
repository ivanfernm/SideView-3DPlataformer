using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBasics : MonoBehaviour
{
    [Header("Life")]
    public Life _life;
    public int _maxlife = 10;
    
    public TMP_Text _lifeText;
   
    [Header("Mana")]
    public Mana _mana;
    public float _maxMana = 10;

    public TMP_Text _manaText;


    private void Awake()
    {
        _life = new Life(_maxlife);
        _lifeText.text = _life.Health.ToString();

        _mana = new Mana(_maxMana);
        _manaText.text = _mana.ManaPoints.ToString();
    }

}
