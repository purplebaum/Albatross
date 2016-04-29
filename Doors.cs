using UnityEngine;
using System.Collections;
using System.Timers;

public class Doors : MonoBehaviour {

    Animator animator;
    bool doorOpen;
    public Transform exit;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            doorOpen = true;
            DoorControl("Open");
            StartCoroutine(AnimationDelay());
            col.transform.position = exit.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (doorOpen)
        {
            doorOpen = false;
            DoorControl("Close");
        }
    }

    void DoorControl(string direction)
    {
        animator.SetTrigger(direction);
    }

    IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(1000f);
    }
}
