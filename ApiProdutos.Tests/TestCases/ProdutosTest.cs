using ApiProdutos.Services.Requests;
using ApiProdutos.Services.Responses;
using ApiProdutos.Tests.Helpers;
using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiProdutos.Tests.TestCases
{
    /// <summary>
    /// Classe de teste para os serviços de produto da API
    /// </summary>
    public class ProdutosTest
    {
        private readonly HttpClient _httpClient;
        private readonly Faker _faker;

        public ProdutosTest()
        {
            _httpClient = new HttpClient();
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public async Task<ProdutoGetResponse> Post_Produtos_Return_Ok()
        {
            #region Criando os dados da requisição

            var request = new ProdutoPostRequest
            {
                Nome = _faker.Commerce.ProductName(),
                Preco = decimal.Parse(_faker.Commerce.Price()),
                Quantidade = 10
            };

            #endregion

            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.PostAsync
                ($"{ApiHelper.Endpoint}/Produtos", ApiHelper.CreateContent(request));

            var response = ApiHelper.CreateResponse<ProdutoGetResponse>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            response.IdProduto.Should().NotBeEmpty();
            response.Nome.Should().Be(request.Nome);
            response.Preco.Should().Be(request.Preco);
            response.Quantidade.Should().Be(request.Quantidade);

            #endregion

            return response;
        }

        [Fact]
        public async Task Put_Produtos_Return_Ok()
        {
            #region Cadastrando e Modificando os dados de um produto

            var request = await Post_Produtos_Return_Ok();

            request.Nome = _faker.Commerce.ProductName();
            request.Preco = decimal.Parse(_faker.Commerce.Price());
            request.Quantidade = 20;

            #endregion

            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.PutAsync
                ($"{ApiHelper.Endpoint}/Produtos", ApiHelper.CreateContent(request));

            var response = ApiHelper.CreateResponse<ProdutoGetResponse>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response.IdProduto.Should().Be(request.IdProduto);
            response.Nome.Should().Be(request.Nome);
            response.Preco.Should().Be(request.Preco);
            response.Quantidade.Should().Be(request.Quantidade);

            #endregion
        }

        [Fact]
        public async Task Put_Produtos_Return_UnprocessableEntity()
        {
            #region Criando os dados da requisição

            var request = new ProdutoPutRequest
            {
                IdProduto = Guid.NewGuid(),
                Nome = _faker.Commerce.ProductName(),
                Preco = decimal.Parse(_faker.Commerce.Price()),
                Quantidade = 10
            };

            #endregion

            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.PutAsync
                ($"{ApiHelper.Endpoint}/Produtos", ApiHelper.CreateContent(request));

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.UnprocessableEntity);

            #endregion
        }

        [Fact]
        public async Task Delete_Produtos_Return_Ok()
        {
            #region Executando o serviço da API e capturando a resposta

            var request = await Post_Produtos_Return_Ok();

            var result = await _httpClient.DeleteAsync
                ($"{ApiHelper.Endpoint}/Produtos/{request.IdProduto}");

            var response = ApiHelper.CreateResponse<ProdutoGetResponse>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response.IdProduto.Should().Be(request.IdProduto);
            response.Nome.Should().Be(request.Nome);
            response.Preco.Should().Be(request.Preco);
            response.Quantidade.Should().Be(request.Quantidade);

            #endregion
        }

        [Fact]
        public async Task Delete_Produtos_Return_UnprocessableEntity()
        {
            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.DeleteAsync
                ($"{ApiHelper.Endpoint}/Produtos/{Guid.NewGuid()}");

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.UnprocessableEntity);

            #endregion
        }

        [Fact]
        public async Task GetAll_Produtos_Return_Ok()
        {
            #region Executando o serviço da API e capturando a resposta

            var request = await Post_Produtos_Return_Ok();

            var result = await _httpClient.GetAsync($"{ApiHelper.Endpoint}/Produtos");
            var response = ApiHelper.CreateResponse<List<ProdutoGetResponse>>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response
                .Should()
                .NotBeEmpty();

            response
                .FirstOrDefault(res => res.IdProduto.Equals(request.IdProduto))
                .Should().NotBeNull();

            #endregion
        }

        [Fact]
        public async Task GetById_Produtos_Return_Ok()
        {
            #region Executando o serviço da API e capturando a resposta

            var request = await Post_Produtos_Return_Ok();

            var result = await _httpClient.GetAsync($"{ApiHelper.Endpoint}/Produtos/{request.IdProduto}");
            var response = ApiHelper.CreateResponse<ProdutoGetResponse>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response.IdProduto.Should().Be(request.IdProduto);
            response.Nome.Should().Be(request.Nome);
            response.Preco.Should().Be(request.Preco);
            response.Quantidade.Should().Be(request.Quantidade);

            #endregion
        }
    }
}



