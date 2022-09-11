using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;

    Health healthComponent;

    void Awake()
    {
        healthComponent = GetComponentInParent<Health>();
    }

    void Start()
    {
        healthSlider.maxValue = healthComponent.maxHealth;
    }

    void Update()
    {
        healthSlider.value = healthComponent.GetCurrentHealth();
    }

    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
