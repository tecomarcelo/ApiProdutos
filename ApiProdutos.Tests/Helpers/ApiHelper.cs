using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Tests.Helpers
{
    public class ApiHelper
    {
        /// <summary>
        /// Retorna o endereço do servidor de testes da API
        /// </summary>
        public static string Endpoint
        {
            get => "http://apiprodutos2-001-site1.itempurl.com/api";
        }

        /// <summary>
        /// Cria um conteúdo JSON para envio na requisição da API
        /// </summary>
        /// <param name="request">Objeto que será enviado na requisição</param>
        /// <returns>Conteúdo da requisição em JSON</returns>
        public static StringContent CreateContent<TRequest>(TRequest request)
            where TRequest : class
        {
            return new StringContent(JsonConvert.SerializeObject(request),
                        Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Deserializa o retorno obtido da API
        /// </summary>
        /// <param name="message">Retorno da requisição da API</param>
        /// <returns>Objeto contendo a resposta obtida da requisição</returns>
        public static TResponse CreateResponse<TResponse>(HttpResponseMessage message)
            where TResponse : class
        {
            return JsonConvert.DeserializeObject<TResponse>
                    (message.Content.ReadAsStringAsync().Result);
        }
    }
}



