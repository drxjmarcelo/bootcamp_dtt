using System.Net;
using System.Net.Http.Json;
using Xunit;
using MinhaApi.Dtos;

public class LotesMinerioTests 
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public LotesMinerioTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAll_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/LotesMinerio");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Post_CreateLote_ReturnsCreated()
    {
        var dto = new CreateLoteMinerioDto
        {
            CodigoLote = "TESTE001",
            MinaOrigem = "Mina Teste",
            TeorFe = 60,
            Umidade = 5,
            Toneladas = 100,
            Status = 1,
            LocalizacaoAtual = "Pátio"
        };

        var response = await _client.PostAsJsonAsync(
            "/api/LotesMinerio", dto);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task GetById_NotFound_WhenInvalid()
    {
        var response = await _client.GetAsync(
            "/api/LotesMinerio/999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}