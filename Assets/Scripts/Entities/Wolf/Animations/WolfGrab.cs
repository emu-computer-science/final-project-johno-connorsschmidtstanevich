using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities.Wolf.Animations
{
    public class WolfGrab : StateMachineBehaviour
    {
        private PlayerInput _player;
        private List<PlayerInput> OtherPlayers
        {
            get
            {
                var ph = new List<PlayerInput>(PlayerInput.all);
                ph.Remove(_player);
                return ph;
            }
        }
    
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
        //     
        // }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player = animator.GetComponent<PlayerInput>();
            foreach (var otherPlayer in OtherPlayers)
            {
                if(animator.GetComponent<Collider2D>().IsTouching(otherPlayer.GetComponent<Player>().HurtBox))
                {
                    animator.SetTrigger("Grab");
                    break;
                }
            }
        }

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
