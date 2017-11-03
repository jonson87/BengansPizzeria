namespace BengansBowlingHallDbLib
{
    public class Round
    {
        public int Id { get; set; }
        public int MatchId { get; set; }     
        public int PlayerOneSerieId { get; set; }    
        public int PlayerTwoSerieId { get; set; }     

        public Match Match { get; set; }
        public Serie PlayerOneSerie { get; set; }
        public Serie PlayerTwoSerie { get; set; }
    }
}
