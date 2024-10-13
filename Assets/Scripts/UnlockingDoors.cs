using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingDoors : MonoBehaviour
{
    public GameObject _Lock;
    public Change DoorChange;
    public BoxCollider2D DoorTrigger;
    public void OnTriggerStay2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                DoorChange.enabled = true;
                DoorTrigger.enabled = true;
                _Lock.SetActive(false);
            }
        }
    }
}
