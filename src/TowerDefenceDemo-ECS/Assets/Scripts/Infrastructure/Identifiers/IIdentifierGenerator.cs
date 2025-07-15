namespace Infrastructure.Identifiers
{
    public interface IIdentifierGenerator
    {
        public int GetId();
        public void ReleaseId(int id);
    }
}