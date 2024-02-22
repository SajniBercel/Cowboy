using Cowboy.Classes;

namespace Cowboy.Interfaces
{
    public interface IHitable
    {
        void Hit(GameComponent Sender);
    }
}
