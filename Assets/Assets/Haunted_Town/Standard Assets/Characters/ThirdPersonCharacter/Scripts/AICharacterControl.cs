using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {



        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
		public Transform target;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

//			anim = GetComponent<Animator>(); // gets the animator links and transitions information
//
	        agent.updateRotation = false;
	        agent.updatePosition = true;
//
//
//			anim.SetBool("isIdle", true);
//			anim.SetBool("isWalking", false);
//			anim.SetBool("isAttacking", false);
        }


        private void Update()
        {
			if (target != null) // if there is a target then
			{
				// Set the path of the character (the path on the navmesh agent) to the destination of the target 
				agent.SetDestination (target.position); 
//				anim.SetBool("isIdle", false);
//				anim.SetBool("isWalking", true);
//				anim.SetBool("isAttacking", false);
			}


			if (agent.remainingDistance > agent.stoppingDistance) // if the path has not been completed
			{
				character.Move (agent.desiredVelocity, false, false);
//				anim.SetBool("isWalking",true);
//				anim.SetBool("isAttacking",false);
			} 
			else // once the AI has reached the destination, stop and 
			{
				character.Move (Vector3.zero, false, false);
//				anim.SetBool("isAttacking",true);
//				anim.SetBool("isWalking",false);
			}



		

        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
