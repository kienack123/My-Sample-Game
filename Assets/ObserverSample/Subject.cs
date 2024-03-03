using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour, ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnNotify();
        }
    }
    
    // Example method that triggers notification
    public void DoSomething()
    {
        // Do something...
        // Then notify observers
        NotifyObservers();
    }
}

