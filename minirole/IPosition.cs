


namespace Peace_Mill
{
    public interface IPosition<out T, in R>
    {
        string Name { get; set; }
        T Get();
        void Set(R value);

    }
}
