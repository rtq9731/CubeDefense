using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
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

    Dictionary<EffectType, List<ParticleSystem>> effectDict = new Dictionary<EffectType, List<ParticleSystem>>();

    private void Start()
    {
        for (int i = 0; i < Enum.GetValues(typeof(EffectType)).Length; i++)
        {
            effectDict.Add((EffectType)i, new List<ParticleSystem>());
        }
    }

    public ParticleSystem GetParticle(EffectType effectType, Transform parent)
    {
        ParticleSystem result = null;

        if (effectDict.TryGetValue(effectType, out List<ParticleSystem> particle))
        {
            if ((result = particle.Find(x => !x.gameObject.activeSelf)) == null)
            {
                result = MakeNewParticle(effectType);
            }
        }

        result.transform.SetParent(parent);
        return result;
    }

    private ParticleSystem MakeNewParticle(EffectType effectType)
    {
        ParticleSystem result = null;
        switch (effectType)
        {
            case EffectType.ExplosionEffect:
                result = Instantiate<ParticleSystem>(explosionParticle);
                break;
            case EffectType.laserEffect:
                result = Instantiate<ParticleSystem>(laserParticle);
                break;
            case EffectType.BuffEffect:
                result = Instantiate<ParticleSystem>(buffParticle);
                break;
            default:
                break;
        }

        if(result)
        {
            result.gameObject.SetActive(false);
            effectDict[effectType].Add(result);
        }
        return result;
    }
}
