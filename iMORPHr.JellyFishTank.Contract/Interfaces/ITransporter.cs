namespace iMORPHr.JellyFishTank.Contract.Interfaces
{
    internal interface ITransporter
    {
        ICompass DirectionProvider
        {
            get;             
        }

        void ProcessInstruction(char instruction);
    }
}
