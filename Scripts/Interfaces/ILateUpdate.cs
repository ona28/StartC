namespace Boxes
{
    public interface ILateUpdate : IController
    {
        void LateUpdate(float deltaTime);
    }
}
