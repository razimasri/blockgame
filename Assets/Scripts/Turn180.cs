using System.Collections;

using UnityEngine;


public class Turn180 : MonoBehaviour
{
    public GameObject player, playerEmpty;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerEmpty = player.transform.parent.gameObject;
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

            anim.SetTrigger("180Trigger");
            anim.SetBool("OnMachine", true);

            StartCoroutine(playerEmpty.GetComponent<PlayerController>().Wait());
            yield return null;
        }


    }
}
