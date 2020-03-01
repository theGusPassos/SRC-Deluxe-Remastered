namespace Assets.Scripts.Systems
{
    public interface IEventListener<Enum>
    {
        void SendEvent(Enum e);
    }
}
