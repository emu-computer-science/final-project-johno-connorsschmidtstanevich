using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities.Wolf.Animations
{
    public class WolfThrow : StateMachineBehaviour
    {
        private PlayerInput _player;
        private static readonly int Hit = Animator.StringToHash("Hit");

        private List<PlayerInput> OtherPlayers
        {
            get
            {
                var ph = new List<PlayerInput>(PlayerInput.all);
                ph.Remove(_player);
                return ph;
            }
        }

        private void Throw(PlayerInput enemyPlayer, Vector2 launchAngle)
        {
            enemyPlayer.GetComponent<Rigidbody2D>().velocity = launchAngle;
            enemyPlayer.gameObject.GetComponent<Animator>().SetTrigger(Hit);
        }
    
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player = animator.GetComponent<PlayerInput>();
            foreach (var otherPlayer in OtherPlayers)
            {
                if(animator.GetComponent<Collider2D>().IsTouching(otherPlayer.GetComponent<Player>().HurtBox))
                {
                    Throw(otherPlayer,
                        animator.GetComponent<Player>().ThrowDirection * animator.GetComponent<Player>().throwStrength);
                    break;
                }
            }
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
