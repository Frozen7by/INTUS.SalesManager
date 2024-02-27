using INTUS.SalesManager.Common.Models;
using System.Net.Http.Json;

namespace INTUS.SalesManager.Client;

public partial class SalesManagerClientService
{
    private readonly HttpClient httpClient;

    public SalesManagerClientService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task<List<LookupDto>> GetElementTypes()
    {
        return httpClient.GetFromJsonAsync<List<LookupDto>>("/api/v1/lookups/elementTypes");
    }

    public Task CreateElementType(LookupDto dto)
    {
        return httpClient.PostAsJsonAsync("/api/v1/lookups/elementTypes", dto);
    }

    public Task<HttpResponseMessage> DeleteElementType(long id = default)
    {
        return httpClient.DeleteAsync($"/api/v1/lookups/elementTypes/{id}");
    }

    public Task<LookupDto> GetElementTypeById(long id = default)
    {
        return httpClient.GetFromJsonAsync<LookupDto>($"/api/v1/lookups/elementTypes/{id}");
    }

    public Task UpdateElementType(LookupDto dto = default)
    {
        return httpClient.PutAsJsonAsync("/api/v1/lookups/elementTypes", dto);
    }

    public Task<List<OrderListDto>> GetOrders()
    {
        return httpClient.GetFromJsonAsync<List<OrderListDto>>("/api/v1/orders");
    }

    public Task CreateOrder(OrderDto order = default)
    {
        return httpClient.PostAsJsonAsync("/api/v1/orders", order);
    }

    public Task<HttpResponseMessage> DeleteOrder(long id = default)
    {
        return httpClient.DeleteAsync($"/api/v1/orders/{id}");
    }

    public Task<OrderDto> GetOrderById(long id = default)
    {
        return httpClient.GetFromJsonAsync<OrderDto>($"/api/v1/orders/{id}");
    }

    public Task<HttpResponseMessage> UpdateOrder(OrderDto order = default)
    {
        return httpClient.PutAsJsonAsync("/api/v1/orders", order);
    }

    public Task<List<LookupDto>> GetStates()
    {
        return httpClient.GetFromJsonAsync<List<LookupDto>>("/api/v1/lookups/states");
    }

    public Task CreateState(LookupDto dto)
    {
        return httpClient.PostAsJsonAsync("/api/v1/lookups/states", dto);
    }

    public Task<HttpResponseMessage> DeleteState(long id = default)
    {
        return httpClient.DeleteAsync($"/api/v1/lookups/states/{id}");
    }

    public Task<LookupDto> GetStateById(long id = default)
    {
        return httpClient.GetFromJsonAsync<LookupDto>($"/api/v1/lookups/states/{id}");
    }

    public Task UpdateState(LookupDto dto = default)
    {
        return httpClient.PutAsJsonAsync("/api/v1/lookups/states", dto);
    }

    public Task<List<SubElementDto>> GetSubElements()
    {
        return httpClient.GetFromJsonAsync<List<SubElementDto>>("/api/v1/subElements");
    }

    public Task CreateSubElement(SubElementDto subElement = default)
    {
        return httpClient.PostAsJsonAsync("/api/v1/subElements", subElement);
    }

    public Task<HttpResponseMessage> DeleteSubElement(long id = default)
    {
        return httpClient.DeleteAsync($"/api/v1/subElements/{id}");
    }

    public Task<SubElementDto> GetSubElementById(long id = default)
    {
        return httpClient.GetFromJsonAsync<SubElementDto>($"/api/v1/subElements/{id}");
    }

    public Task<HttpResponseMessage> UpdateSubElement(SubElementDto subElement = default)
    {
        return httpClient.PutAsJsonAsync("/api/v1/subElements", subElement);
    }

    public Task<List<WindowListDto>> GetWindows()
    {
        return httpClient.GetFromJsonAsync<List<WindowListDto>>("/api/v1/windows");
    }

    public Task CreateWindow(WindowDto window = default)
    {
        return httpClient.PostAsJsonAsync("/api/v1/windows", window);
    }

    public Task<HttpResponseMessage> DeleteWindow(long id = default)
    {
        return httpClient.DeleteAsync($"/api/v1/windows/{id}");
    }

    public Task<WindowDto> GetWindowById(long id = default)
    {
        return httpClient.GetFromJsonAsync<WindowDto>($"/api/v1/windows/{id}");
    }

    public Task<HttpResponseMessage> UpdateWindow(WindowDto window = default)
    {
        return httpClient.PutAsJsonAsync("/api/v1/windows", window);
    }
}