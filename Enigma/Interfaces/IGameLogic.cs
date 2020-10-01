namespace Enigma.Interfaces
{
    interface IGameLogic
    {
        public string Hint { get; set; }
        public void GenerateRandomNr(int[]anyArray);
        public int[] GetRestOfNrInSequence(int[]anyArray);
    }
}
