using CrudFornecedores.Models;
using Microsoft.Extensions.WebEncoders.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace CrudFornecedores.Integrations
{
	public class Ploomes
	{ 
		internal static async Task CreateCompanyPloomesAsync(Fornecedor fornecedor)
		{

			string key = "7DC64F4804E229652F62193E29E18776A5C9007DCC3E1B7A0392A71F19CFE9C67D761A4580DC9A88300905DA065401EAADB01CF988E80E408C0C80ED559C98F4";
			string url = "https://app24-api2.ploomes.com/Contacts";

			try
			{
				IDictionary<string, string> body = new Dictionary<string, string>()
				{
					{"Name", $"{fornecedor.Nome}"},
					{"Register", $"{fornecedor.Cnpj}"}
				};

				var client = new HttpClient();
				var request = new HttpRequestMessage();
				var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
				content.Headers.Add($"User-Key", key);

				var response = await client.PostAsync(url, content);

				var resposta = await response.Content.ReadAsStringAsync();

				// Preenche o Id Ploomes aqui no sistema
				if (response.IsSuccessStatusCode)
				{
					var res = JsonConvert.DeserializeObject<ResponsePloomes>(resposta);
					var id = res.value[0].Id;

					fornecedor.IdPloomes = id;
				}

				//Console.WriteLine(response.StatusCode);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"{ex.Message}");
			}
		}

		internal static async Task DeleteCompanyPloomesAsync(Fornecedor fornecedor)
		{

			string key = "7DC64F4804E229652F62193E29E18776A5C9007DCC3E1B7A0392A71F19CFE9C67D761A4580DC9A88300905DA065401EAADB01CF988E80E408C0C80ED559C98F4";
			string url = "https://app24-api2.ploomes.com/Contacts";


			try
			{
				var client = new HttpClient();


				var idExclusao = fornecedor.IdPloomes;

				var message = new HttpRequestMessage(HttpMethod.Delete, url + $"({idExclusao})");
				message.Headers.Add($"User-Key", key);
				var response = await client.SendAsync(message);

				if (response.StatusCode == HttpStatusCode.OK)
				{
					Console.WriteLine("Cliente deletado com sucesso!");
				}
				else
				{
					Console.WriteLine($"Houve algum erro na exclusão, o Status da requisição é: {response.StatusCode}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"{ex.Message}");
			}
			
		}
	}
}
