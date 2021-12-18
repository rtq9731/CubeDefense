using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum effectType
{
    ExplosionEffect,
    laserEffect,
    BuffEffect
}
public class EffectManager : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticle = null;
    [SerializeField] ParticleSystem laserParticle = null;
    [SerializeField] ParticleSystem buffParticle = null;

    Dictionary<effectType, List<ParticleSystem>> effectDict = new Dictionary<effectType, List<ParticleSystem>>();

    private void Start()
    {
        for (int i = 0; i < Enum.GetValues(typeof(effectType)).Length; i++)
        {
            effectDict.Add((effectType)i, new List<ParticleSystem>());
        }
    }

    public void GetParticle()
    {

    }
}
