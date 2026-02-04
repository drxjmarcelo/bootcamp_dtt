namespace MinhaApi.Models
{
    class LoteMinerio()
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Codigo { get; set; }
        public decimal ToneladaMinerada { get; set; }
        public DateTime DataMineracao { get; set; }
    }
}