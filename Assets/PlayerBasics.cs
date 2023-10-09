using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBasics : MonoBehaviour
{
    public Life _life;
    public int _maxlife = 10;

    public TMP_Text _lifeText;

    private void Awake()
    {
        _life = new Life(_maxlife);
        _lifeText.text = _life.Health.ToString();
    }

}
