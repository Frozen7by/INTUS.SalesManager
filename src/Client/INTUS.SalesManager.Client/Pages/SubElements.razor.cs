using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Client.Pages;

public partial class SubElements
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

    protected IEnumerable<SubElementDto> subElements;

    protected RadzenDataGrid<SubElementDto> grid0;
    protected int count;

    protected async Task Grid0LoadData(LoadDataArgs args)
    {
        try
        {
            subElements = await SalesManagerClientService.GetSubElements();
            count = subElements.Count();
        }
        catch (System.Exception ex)
        {
            NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load SubElements" });
        }
    }

    protected async Task AddButtonClick(MouseEventArgs args)
    {
        await DialogService.OpenAsync<AddSubElement>("Add SubElement", null);
        await grid0.Reload();
    }

    protected async Task EditRow(SubElementDto args)
    {
        await DialogService.OpenAsync<EditSubElement>("Edit SubElement", new Dictionary<string, object> { {"Id", args.Id} });
        await grid0.Reload();
    }

    protected async Task GridDeleteButtonClick(MouseEventArgs args, SubElementDto subElement)
    {
        try
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var deleteResult = await SalesManagerClientService.DeleteSubElement(id:subElement.Id);

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
                Detail = $"Unable to delete SubElement"
            });
        }
    }
}