using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Client.Pages;

public partial class Windows
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

    protected IEnumerable<WindowListDto> windows;

    protected RadzenDataGrid<WindowListDto> grid0;
    protected int count;

    protected async Task Grid0LoadData(LoadDataArgs args)
    {
        try
        {
            windows = await SalesManagerClientService.GetWindows();
            count = windows.Count();
        }
        catch (System.Exception ex)
        {
            NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Windows" });
        }
    }

    protected async Task AddButtonClick(MouseEventArgs args)
    {
        await DialogService.OpenAsync<AddWindow>("Add Window", null);
        await grid0.Reload();
    }

    protected async Task EditRow(WindowListDto args)
    {
        await DialogService.OpenAsync<EditWindow>("Edit Window", new Dictionary<string, object> { {"Id", args.Id} });
        await grid0.Reload();
    }

    protected async Task GridDeleteButtonClick(MouseEventArgs args, WindowListDto window)
    {
        try
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var deleteResult = await SalesManagerClientService.DeleteWindow(id:window.Id);

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
                Detail = $"Unable to delete Window"
            });
        }
    }
}