namespace MinhaApi.Dtos;

public class LoteMinerioResponseDto
{
    public string CodigoLote { get; set; } = string.Empty;
    public string MinaOrigem { get; set; } = string.Empty;
    public double TeorFe { get; set; }
    public double Umidade { get; set; }
    public double SiO2 { get; set; }
    public double P { get; set; }
    public double Toneladas { get; set; }
    public DateTime DataProducao { get; set; }
    public int Status { get; set; }
    public string LocalizacaoAtual { get; set; } = string.Empty;
}
