namespace iMORPHr.JellyFishTank.Contract.Interfaces
{
    public interface IJellyFish
    {
        ICell CurrentCell { get; set; }
        Orientation Direction { get; }
        bool IsLost { get; }

        void ProcessInstruction(string instruction);
    }
}
