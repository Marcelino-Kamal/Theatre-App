using System.Text.Json;
using Theatre_App.Helpers;
using Theatre_App.DTO.SearchDtos;
namespace Theatre_App.Service.SearchServices
{


    public class SearchService : ISearchService
    {
        private readonly string _scriptPath = "Scripts/Search function.py"; 

        public List<SearchResultDto> Search(string query)
        {
            string rawOutput = PythonRunner.RunPythonScript(_scriptPath, query);
            var dict = JsonSerializer.Deserialize<Dictionary<int, double>>(rawOutput);

            return dict.Select(kvp => new SearchResultDto
            {
                Id = kvp.Key,
                Score = kvp.Value
            }).ToList();
        }
    }
}