using UnityEngine;
// Concrete observer implementation
public class Observer : MonoBehaviour, IObserver
{
    public void OnNotify()
    {
        Debug.Log("Observer received notification.");
        // Do something in response to the notification
    }
}
