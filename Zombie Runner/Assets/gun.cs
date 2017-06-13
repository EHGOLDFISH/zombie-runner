using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

	public Camera fpsCam;
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;
	private AudioSource gunAudio;


	void Start(){
		gunAudio = GetComponent<AudioSource> ();
		fpsCam = GetComponentInParent<Camera>();
	}


	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
		muzzleFlash.Play ();

		RaycastHit hit;
		gunAudio.Play ();

		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
			//Debug.Log (hit.transform.name);

			EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) {
				enemyHealth.TakeDamage (damage);
			}

			GameObject impactGo = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impactGo, 1f);
		}
    }
}
