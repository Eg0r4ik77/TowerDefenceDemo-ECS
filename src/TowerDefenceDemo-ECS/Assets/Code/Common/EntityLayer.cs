namespace Code.Common
{
    public enum EntityLayer
    {
        Enemy = 1
    }
    
    public static class EntityLayerExtensions
    {
        public static int AsMask(this EntityLayer layer) => 1 << (int)layer;

        public static bool Matches(this EntityLayer layer, int layerMask) =>
            ((1 << (int)layer) & layerMask) != 0;
    }
}