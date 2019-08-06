namespace GameOfLifeLibrary
{
    public interface IWorld
    {
        int[] WorldSize { get; }
        void CellsSetUp();
        bool IsAnyCellAlive();
        void Tick();
    }
}