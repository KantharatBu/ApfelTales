using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 1000;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
    }
    private void Update()
    {
        CurrentHealth = GameManager.instance.hp;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
