namespace MinhaApi.Dtos;

public class UpdateLoteMinerioDto
{
    public string? MinaOrigem { get; set; }
    public double? TeorFe { get; set; }
    public double? Umidade { get; set; }
    public double? SiO2 { get; set; }
    public double? P { get; set; }
    public double? Toneladas { get; set; }
    public DateTime? DataProducao { get; set; }
    public int? Status { get; set; }
    public string? LocalizacaoAtual { get; set; }
}
