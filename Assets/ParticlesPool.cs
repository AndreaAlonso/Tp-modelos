using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesPool : MonoBehaviour {

    public int amount;
    public Particles prefab;
    private Pool<Particles> _particlesPool;

    private static ParticlesPool _instance;
    public static ParticlesPool Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
        _particlesPool = new Pool<Particles>(amount, ParticleFactory, Particles.InitializeParticle, Particles.DisposeParticle);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _particlesPool.GetObjectFromPool();
        }
    }

    public Particles GetParticle()
    {

        var particle = _particlesPool.GetObjectFromPool();
        particle.Initialize();
        return particle;
    }

    private Particles ParticleFactory()
    {
        return Instantiate<Particles>(prefab);
    }
    public void ReturnParticleToPool(Particles particle)
    {
        _particlesPool.DisablePoolObject(particle);
    }
}
