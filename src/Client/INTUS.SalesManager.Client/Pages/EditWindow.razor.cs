using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Client.Pages;

public partial class EditWindow
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

    [Parameter]
    public long Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        window = await SalesManagerClientService.GetWindowById(id:Id);
    }

    protected bool errorVisible;
    protected WindowDto window;

    protected IEnumerable<OrderListDto> ordersForOrderId;


    protected int ordersForOrderIdCount;
    protected OrderListDto ordersForOrderIdValue;
    protected async Task ordersForOrderIdLoadData(LoadDataArgs args)
    {
        try
        {
            ordersForOrderId = await SalesManagerClientService.GetOrders();
            ordersForOrderIdCount = ordersForOrderId.Count();

        }
        catch (System.Exception ex)
        {
            NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load Order" });
        }
    }
    protected async Task FormSubmit()
    {
        try
        {
            await SalesManagerClientService.UpdateWindow(window);
            DialogService.Close(window);
        }
        catch
        {
            errorVisible = true;
        }
    }

    protected Task CancelButtonClick(MouseEventArgs args)
    {
        DialogService.Close(null);
        return Task.CompletedTask;
    }
}