using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Client.Pages;

public partial class ElementTypes
{
    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }

    [Inject]
    public SalesManagerClientService SalesManagerClientService { get; set; }

    protected IEnumerable<LookupDto> elementTypes;

    protected RadzenDataGrid<LookupDto> grid0;
    protected int count;

    protected async Task Grid0LoadData(LoadDataArgs args)
    {
        try
        {
            elementTypes = await SalesManagerClientService.GetElementTypes();
            count = elementTypes.Count();
        }
        catch (System.Exception ex)
        {
            NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load ElementTypes" });
        }
    }

    protected async Task AddButtonClick(MouseEventArgs args)
    {
        await DialogService.OpenAsync<AddElementType>("Add ElementType", null);
        await grid0.Reload();
    }

    protected async Task EditRow(LookupDto args)
    {
        await DialogService.OpenAsync<EditElementType>("Edit ElementType", new Dictionary<string, object> { {"Id", args.Id} });
        await grid0.Reload();
    }

    protected async Task GridDeleteButtonClick(MouseEventArgs args, LookupDto elementType)
    {
        try
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var deleteResult = await SalesManagerClientService.DeleteElementType(id:elementType.Id);

                if (deleteResult != null)
                {
                    await grid0.Reload();
                }
            }
        }
        catch
        {
            NotificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Error,
                Summary = $"Error",
                Detail = $"Unable to delete ElementType"
            });
        }
    }
}