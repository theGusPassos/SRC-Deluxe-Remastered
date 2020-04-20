namespace Assets.Scripts.Systems.Observable
{
    public interface IEventListener<Enum>
    {
        void SendEvent(Enum e);
    }
}
