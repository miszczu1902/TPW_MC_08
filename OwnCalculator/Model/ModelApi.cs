namespace Model;

public abstract class ModelApi
{
    public abstract int Radius { get; }

    public static ModelApi CreateApi()
    {
        return new Api();
    }
    
    internal class Api : ModelApi
    {
        public override int Radius => 100;
    }
}