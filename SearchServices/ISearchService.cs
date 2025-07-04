using Theatre_App.DTO.SearchDtos;
namespace Theatre_App.Service.SearchServices
{
    public interface ISearchService
    {
        List<SearchResultDto> Search(string query);
    }
}
