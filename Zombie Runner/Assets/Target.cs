using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Target : MonoBehaviour {
	
	public Transform zombieSpawnPoints;
	private Transform[] spawnPoints;

	public float health = 50f;

	private int difficultyCounter = 0;
	private bool isDead = false;
	AudioSource enemyAudio; 
	Animator anim; 

	void Awake(){
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
	}

	void Start()
	{
		//spawnPoints = zombieSpawnPoints.GetComponentsInChildren<Transform>();
	}

	public void TakeDamage(float amount){
		health -= amount;
		if (isDead)
			return;
		if (health <= 0f) {
			isDead = true;
				Die();
		}
	}

	void Die(){
		GetComponent<NavMeshAgent>().enabled = false;
		anim.SetTrigger("Dead");
		enemyAudio.Play ();
		Destroy (gameObject, 2f);
		//Destroy (gameObject);
//		if (difficultyCounter >= 5) {
//			Destroy (gameObject);
//			if (GameObject.FindWithTag ("zombie") == null) {
//				//win screen
//			}
//		} else {
//			Respawn ();
//		}

	}

	private void Respawn()
	{
		//difficultyCounter++;
		//health = 50 + (10 * difficultyCounter);
		//int i = Random.Range(1, spawnPoints.Length);
		//transform.position = spawnPoints[i].transform.position;
		//anim.SetTrigger("Respawn");
	}


}
