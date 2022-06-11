using ApiProdutos.Services.Requests;
using ApiProdutos.Services.Responses;
using ApiProdutos.Tests.Helpers;
using FluentAssertions;
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
    public class LoginTest
    {
        private readonly HttpClient _httpClient;

        public LoginTest()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public async Task<LoginGetResponse> Post_Login_Returns_Ok()
        {

            #region Criando os dados da requisição

            var request = new LoginPostRequest
            {
                Login = "teste2022",
                Senha = "@Teste2022"
            };

            #endregion

            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.PostAsync
                ($"{ApiHelper.Endpoint}/Login", ApiHelper.CreateContent(request));

            var response = ApiHelper.CreateResponse<LoginGetResponse>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            #endregion

            return response;
        }

        [Fact]
        public async Task Post_Login_Returns_Unauthorized()
        {

            #region Criando os dados da requisição

            var request = new LoginPostRequest
            {
                Login = "testeABC",
                Senha = "@TesteABC"
            };

            #endregion

            #region Executando o serviço da API e capturando a resposta

            var result = await _httpClient.PostAsync
                ($"{ApiHelper.Endpoint}/Login", ApiHelper.CreateContent(request));

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.Unauthorized);

            #endregion
        }
    }
}



