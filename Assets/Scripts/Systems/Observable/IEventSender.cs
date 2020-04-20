using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Systems.Observable
{
    public abstract class IEventSender<Enum> : MonoBehaviour
    {
        private List<IEventListener<Enum>> listeners
            = new List<IEventListener<Enum>>();

        public void SubscribeToEvent(params IEventListener<Enum>[] listener)
            => this.listeners.AddRange(listener);

        protected void SendEvent(Enum e)
        {
            foreach (var listener in listeners)
                listener.SendEvent(e);
        }
    }
}
