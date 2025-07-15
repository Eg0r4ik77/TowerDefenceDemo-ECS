using Entitas;

namespace Infrastructure.Systems
{
    public interface ISystemFactory
    {
        public T Create<T>() where T : ISystem;
        public T Create<T>(params object[] args) where T : ISystem;
    }
}