using UnityEngine;
using System.Collections;
/// <summary>
/// **********BruceXu*******16.11.17*********
/// </summary>
public class ParticlesSize : MonoBehaviour
{

    static ParticleSystem[] particles;

    static float[] OldStartSize;
    static float[] OldStartSpeed;
    static float[] OldStartRotation;
    static float[] OldgravityModifier;
    static int particlesLength;
    //// Use this for initialization
    void Start()
    {
        particles = GetComponentsInChildren<ParticleSystem>(true);
        particlesLength = particles.Length;
        if (particlesLength == 0)
        {
            return;
        }
        InitParticlySystem();
        Destroy(gameObject, 1f);
    }

    /// <summary>
    /// 初始化获取所有粒子
    /// </summary>
    void InitParticlySystem()
    {
        OldStartSize = new float[particlesLength];
        OldStartSpeed = new float[particlesLength];
        OldStartRotation = new float[particlesLength];
        OldgravityModifier = new float[particlesLength];

        for (int idx = 0; idx < particlesLength; idx++)
        {
            var particle = particles[idx];
            if (particle == null) continue;
            OldStartSize[idx] = particle.startSize;
            OldStartSpeed[idx] = particle.startSpeed;
            OldStartRotation[idx] = particle.startRotation;
            OldgravityModifier[idx] = particle.gravityModifier;
        }

        //手动缩小
        for (int idx = 0; idx < particlesLength; idx++)
        {
            var particle = particles[idx];
            if (particle == null) continue;
            particle.startSize = 0.2f * OldStartSize[idx];
            particle.startSpeed = 0.2f * OldStartSpeed[idx];
            particle.startRotation = 0.2f * OldStartRotation[idx];
            particle.gravityModifier = 0.2f * OldgravityModifier[idx];
        }
    }
    /// <summary>
    /// 缩放粒子
    /// </summary>
    /// <param name="scale">绽放系数</param>
    public static void ScaleParticleSystem(float scale)
    {
        for (int idx = 0; idx < particlesLength; idx++)
        {
            var particle = particles[idx];
            if (particle == null) continue;
            particle.startSize = scale * OldStartSize[idx];
            particle.startSpeed = scale * OldStartSpeed[idx];
            particle.startRotation = scale * OldStartRotation[idx];
            particle.gravityModifier = scale * OldgravityModifier[idx];
        }
    }
}