using UnityEngine;


public class playerPause : StateMachineBehaviour
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
 //  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //  {
  //    
  //  }

    public LayerMask layermask;



    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        GameObject player = animator.gameObject;
        if (animator.GetBool("OnMachine"))
        {
            if (!CollisionCheck(player, animator))

            {
                animator.SetTrigger("interrupt");
      
                Debug.Log("interrupt");
            }

        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //  {
  //
   //    
   //
  //  }

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


    public bool CollisionCheck(GameObject player, Animator animator)
    {
        Transform[] playerCubes = player.transform.GetComponentsInChildren<Transform>(); //get componenet expensive to call everyloop so it is cached
        foreach (Transform block in playerCubes)  // TODO: swap to a for loop when you can but keeping this readable for now as a beginner
        {
            Collider[] cubes = Physics.OverlapSphere(block.position, 0.7f, layermask);

            foreach (Collider i in cubes)
            {
                if (!i.transform.IsChildOf(player.transform))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
