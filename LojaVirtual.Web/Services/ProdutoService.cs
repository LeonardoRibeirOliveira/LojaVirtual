using LojaVirtual.Web.Models;
using LojaVirtual.Web.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace LojaVirtual.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/produto/";
        private readonly JsonSerializerOptions _options;
        private ProdutoViewModel produtoViewModel;
        private IEnumerable<ProdutoViewModel> produtoViewModelList;
        public ProdutoService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<ProdutoViewModel> CreateProduct(ProdutoViewModel produto)
        {
            var client = _clientFactory.CreateClient("APIProduto");
            StringContent content = new StringContent(JsonSerializer.Serialize(produtoViewModel), Encoding.UTF8, "application/json"); //trata os valores para um Json
            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    produtoViewModelList = await JsonSerializer.DeserializeAsync<IEnumerable<ProdutoViewModel>>(apiResponse, _options); //Desserializa o conteúdo da resposta em uma lista de objetos "ProdutoViewModel" usando o JSON deserialization
                }
                else
                {
                    return null;
                }
            }
            return produtoViewModel;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            var client = _clientFactory.CreateClient("APIProduto");
            using (var response = await client.DeleteAsync(apiEndpoint + id)) 
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    produtoViewModelList = await JsonSerializer.DeserializeAsync<IEnumerable<ProdutoViewModel>>(apiResponse, _options); //Desserializa o conteúdo da resposta em uma lista de objetos "ProdutoViewModel" usando o JSON deserialization
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAllProdutos()
        {
            var client = _clientFactory.CreateClient("APIProduto");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if(response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    produtoViewModelList = await JsonSerializer.DeserializeAsync<IEnumerable<ProdutoViewModel>>(apiResponse, _options); //Desserializa o conteúdo da resposta em uma lista de objetos "ProdutoViewModel" usando o JSON deserialization
                }
                else
                {
                    return null;
                }
            }
            return produtoViewModelList;
        }

        public async Task<ProdutoViewModel> GetProdutosById(int id)
        {
            var client = _clientFactory.CreateClient("APIProduto");
            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    produtoViewModelList = await JsonSerializer.DeserializeAsync<IEnumerable<ProdutoViewModel>>(apiResponse, _options); //Desserializa o conteúdo da resposta em uma lista de objetos "ProdutoViewModel" usando o JSON deserialization
                }
                else
                {
                    return null;
                }
            }
            return produtoViewModel;
        }

        public async Task<ProdutoViewModel> UpdateProduct(ProdutoViewModel produto)
        {
            var client = _clientFactory.CreateClient("APIProduto");
            ProdutoViewModel produtoUpdate = new ProdutoViewModel();
            using (var response = await client.PutAsJsonAsync(apiEndpoint, produto))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    produtoViewModelList = await JsonSerializer.DeserializeAsync<IEnumerable<ProdutoViewModel>>(apiResponse, _options); //Desserializa o conteúdo da resposta em uma lista de objetos "ProdutoViewModel" usando o JSON deserialization
                }
                else
                {
                    return null;
                }
            }
            return produtoUpdate;
        }
    }
}
