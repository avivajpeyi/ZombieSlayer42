using UnityEngine;
using System.Collections;

namespace S3
{
public class Enemy_Sounds : MonoBehaviour {


	private Enemy_Master enemyMaster;
	private Transform myTransform;
	public float randomGroanVolume = 0.9f;
	public float takeDamageVolume = 0.9f;
	public float biteVolume = 0.9f;
	public AudioClip biteSound;
	public AudioClip takeDamageSound;
		public AudioClip[] randomGroanSound;

		private int groanRandomNumber = 0;



	void OnEnable()
	{
		SetInitialReferences();
//		if (groanRandomNumber == Random.Range (0, 100))// && SoundIsPlayuing == false)
		enemyMaster.EventEnemyWalking += PlayRandomGroanSound; 
	}
	

		void OnDisable()
		{
			enemyMaster.EventEnemyWalking -= PlayRandomGroanSound; 
		}


			void SetInitialReferences()
			{
				enemyMaster = GetComponent<Enemy_Master>();
				myTransform = transform;
				groanRandomNumber = Random.Range (0, 10); 
			}
	
//
//		void Update () //MIGHT MAKE THE GAME SLOW!!! 
//		{
//
//			if (groanRandomNumber == Random.Range (0, 100)) // if we get the same random number as we ehad set in the start, we will play the noise
//				PlayRandomGroanSound (); 
//
//		}
//



	public void PlayBiteSound() //Called by the BITE animation event
	{


		if (biteSound != null)
				{
					AudioSource.PlayClipAtPoint(biteSound, myTransform.position, biteVolume);
				}
	}


	public void PlayTakeDamageSound() //Called by the TAKE DAMAGE animation event
	{
		if (takeDamageSound != null)
		{
			AudioSource.PlayClipAtPoint(takeDamageSound , myTransform.position, takeDamageVolume );
		}
	}


		public void PlayRandomGroanSound() //Called by enemy master
		{



			if (groanRandomNumber == Random.Range (0, 10) &&   randomGroanSound.Length > 0)
			{
				int index = Random.Range(0, randomGroanSound.Length);
				AudioSource.PlayClipAtPoint(randomGroanSound[index], myTransform.position, randomGroanVolume);
			}

		
	}

}
}

