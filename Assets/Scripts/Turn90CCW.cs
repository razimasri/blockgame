using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn90CCW : MonoBehaviour
{
    public GameObject player, playerEmpty;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerEmpty = GameObject.Find("PlayerEmpty");
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(MachineTrigger());
        playerEmpty.GetComponent<PlayerController>().pause = true;

    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("OnMachine", false);
    }

    private IEnumerator MachineTrigger()
    {
        Debug.Log("MachineTrigger");
        yield return new WaitForSeconds(0.1f);//i know this isnot the correct way to do it make it an event but i am tired now
        if (player.transform.position == transform.position)
        {

            anim.SetTrigger("90CCW");
            anim.SetBool("OnMachine", true);

            StartCoroutine(playerEmpty.GetComponent<PlayerController>().Wait());
            yield return null;
        }


    }

}
