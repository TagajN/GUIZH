namespace CommandGyakorlatban
{
    public interface ICounterLogic
    {
        int Counter { get; set; }

        void Increase();
    }
}