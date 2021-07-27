using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Es.PesquisaCep.Infrastructure.Implementation.Base
{
    public class BaseApiRestRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _client;

        private int _timeout { get { return 30; } }

        public BaseApiRestRepository(string client, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _client = client;
        }

        public async Task<T> GetAsync<T>(string route, Dictionary<string, object> parametros, Dictionary<string, object> header)
        {
            var client = _clientFactory.CreateClient(_client);
            client.Timeout = new TimeSpan(0, 0, _timeout);

            ObterQuery(ref route, parametros);

            ObterHeaders(client, header);

            var response = await client.GetAsync(route, HttpCompletionOption.ResponseHeadersRead);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(stream);
                }
                else
                {
                    BaseApiResponse responseBase = new BaseApiResponse { Sucesso = false, MensagemErro = await response.Content.ReadAsStringAsync() };
                    var retorno = JsonConvert.SerializeObject(responseBase);
                    return JsonConvert.DeserializeObject<T>(retorno);
                }
            }
            finally
            {
                response.Dispose();
            }
        }

        private void ObterHeaders(HttpClient client, Dictionary<string, object> header)
        {
            client.DefaultRequestHeaders.Clear();

            if (header != null && header.Any())
            {
                foreach (var item in header)
                    client.DefaultRequestHeaders.Add(item.Key, item.Value.ToString());
            }
        }

        private void ObterQuery(ref string route, Dictionary<string, object> parameters)
        {
            string queryString = parameters == null || parameters.Count == 0
                ? string.Empty : ("?" + string.Join("&", parameters.Select(parametro => BuscarValorParametro(parametro))));
            route = string.Format("{0}{1}", route, queryString);
        }

        private string BuscarValorParametro(KeyValuePair<string, object> parameters)
        {
            return string.Format("{0}={1}", HttpUtility.UrlEncode(parameters.Key), ParseToString(parameters.Value));
        }

        private static string ParseToString(object value)
        {
            string vValue = value.ToString();
            if (vValue != null && value is string)
                vValue = (string)value;
            else if (value is int)
                vValue = ((int)value).ToString();
            else if (value is DateTime)
                vValue = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            else if (value is double)
                vValue = ((double)value).ToString("G", CultureInfo.CreateSpecificCulture("en-US"));
            else if (value is bool)
                vValue = ((bool)value ? "true" : "false");
            else
                throw new NotImplementedException();

            return HttpUtility.UrlEncode(vValue);
        }
    }
}
