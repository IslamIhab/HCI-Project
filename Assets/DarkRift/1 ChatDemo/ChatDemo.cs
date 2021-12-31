using DarkRift;
using DarkRift.Client;
using DarkRift.Client.Unity;
using UnityEngine;
using UnityEngine.UI;

public class ChatDemo : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The client to communicate with the server via.")]
    UnityClient client;

    public CameraPointer cameraPointer;
    public ViewerEditor viewer;

    void Awake()
    {
        client.MessageReceived += Client_MessageReceived;
    }

    private void Client_MessageReceived(object sender, MessageReceivedEventArgs e)
    {
        using (Message message = e.GetMessage() as Message)
        {
            using (DarkRiftReader reader = message.GetReader())
            {
                string mess = reader.ReadString();
                if(mess == "x")
                {
                    cameraPointer.PressButton();
                }
                else
                {
                    Debug.Log("Hello");
                    viewer.GenerateCube(mess);
                }
            }
        }
    }

    public void MessageEntered(string x)
    {
        using (DarkRiftWriter writer = DarkRiftWriter.Create())
        {
            writer.Write(x);

            using (Message message = Message.Create(0, writer))
            {
                client.SendMessage(message, SendMode.Reliable);
            }
        }
    }
}
