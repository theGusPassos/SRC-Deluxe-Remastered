using System;

namespace Assets.Scripts.Systems
{
    public interface IEventSender<Enum>
    {
        void SubscribeToEvent(IEventListener<Enum> listener);
        void RemoveListener(IEventListener<Enum> listener);
    }
}
