using UnityEngine;
using Oculus;

public class GrabButtonController : MonoBehaviour
{
    private void Update()
    {
        // Check if the Oculus grab button is pressed
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)) // Adjust for the specific button you're using
        {
            // Send a message or perform an action in Unity
            SendMessageToUnity();
        }
    }

    private void SendMessageToUnity()
    {
        Debug.Log("Grab button pressed! Sending message...");
        // You can put your message-sending logic here
    }
}
