using iMORPHr.JellyFishTank.Contract.Interfaces;

namespace iMORPHr.JellyFishTank.Contract
{
    public class JellyFish: IJellyFish
    {
        #region Properties
        private ICell currentCell;
        public ICell CurrentCell { get => currentCell; set => currentCell = value; }
        //Tank container;
        
        bool isLost;        

        public bool IsLost { get => isLost; }
        
        private ITransporter vehicle;
        
        //internal ITransporter Vehicle { get => vehicle; set => vehicle = value; }

        public Orientation Direction
        {
            get
            {
                return this.vehicle.DirectionProvider.Direction;
            }
        }
        #endregion

        #region Constructor
        public JellyFish(ICell cellToStart, Orientation direction)
        {
            this.CurrentCell = cellToStart;
            vehicle = new Transporter(direction, this);
        }
        #endregion

        #region Internal Methods
        internal void MoveToCell(Coordinates newCoordinates)
        {
            ICell newCell = this.currentCell.Container.Grid[newCoordinates.X, newCoordinates.Y];            
            this.currentCell.JellyFishes.Remove(this);
            newCell.JellyFishes.Add(this);
            this.currentCell = newCell;
        }
        
        internal void SignalInabilityToMoveOutOfBounds()
        {
            if (!this.currentCell.IsScented)
            {
                this.isLost = true;
                this.currentCell.IsScented = true;
            }
        }
        #endregion

        #region Public Methods
        public void ProcessInstruction(string instruction)
        {
            for (int i = 0; i < instruction.Length; i++)
            {
                if (!IsLost)
                {
                    char instr = char.Parse(instruction.Substring(i, 1));
                    this.vehicle.ProcessInstruction(instr);
                }
            }
        }
        #endregion
    }
}
