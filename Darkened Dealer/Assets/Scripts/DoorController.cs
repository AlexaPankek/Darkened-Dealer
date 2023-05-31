using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private string doorOpen = "DoorOpen";
    [SerializeField] private string doorClose = "DoorClose";

    public void OpenDoor()
    {
        myDoor.Play(doorOpen, 0, 0.0f);
        gameObject.SetActive(false);
    }

    public void CloseDoor()
    {
        myDoor.Play(doorClose, 0, 0.0f);
        gameObject.SetActive(false);
    }
}