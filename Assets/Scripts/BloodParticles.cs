using UnityEngine;
using System.Collections;

public class BloodParticles : MonoBehaviour {

	ParticleSystem m_System;
	ParticleSystem.Particle[] m_Particles;
	public float m_mass = 1f;
	public float max_speed = 10f;

	public Vector2 initVelocity;
	private bool inited;

	[SerializeField] private LayerMask m_WhatIsGround; 

	private void LateUpdate()
	{
		InitializeIfNeeded();
		
		// GetParticles is allocation free because we reuse the m_Particles buffer between updates
		int numParticlesAlive = m_System.GetParticles(m_Particles);
		
		// Change only the particles that are alive
		for (int i = 0; i < numParticlesAlive; i++)
		{

			if(colliding(m_Particles[i])){
				m_Particles[i].velocity = Vector3.zero;
				continue;
			};

			Vector2 gravet = Gravity.gravitize(Vector2.down*m_mass);
		
			m_Particles[i].velocity += new Vector3(gravet.x, gravet.y, 0f);

			if(m_Particles[i].velocity.magnitude > max_speed){
				m_Particles[i].velocity = m_Particles[i].velocity.normalized * max_speed;
			}

			if(!inited){
				m_Particles[i].velocity += new Vector3(initVelocity.x, initVelocity.y, 0f);
			}

			m_Particles[i].velocity = new Vector3(m_Particles[i].velocity.x, m_Particles[i].velocity.y, 0f);
		}
		
		// Apply the particle changes to the particle system
		m_System.SetParticles(m_Particles, numParticlesAlive);
	
		inited = true;
	}

	bool colliding(ParticleSystem.Particle particle){
		Vector3 worldPos = gameObject.transform.position + particle.position;
		Collider2D[] colliders = Physics2D.OverlapCircleAll (new Vector2(worldPos.x, worldPos.y), particle.size,m_WhatIsGround);

		return colliders.Length > 0;
	}

	void InitializeIfNeeded()
	{
		if (m_System == null)
			m_System = GetComponent<ParticleSystem>();
		
		if (m_Particles == null || m_Particles.Length < m_System.maxParticles)
			m_Particles = new ParticleSystem.Particle[m_System.maxParticles]; 
	}

}
