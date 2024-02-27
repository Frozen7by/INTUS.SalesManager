using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Client.Pages;

public partial class AddOrder
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

    protected override Task OnInitializedAsync()
    {
        order = new OrderDto() { State = new LookupDto() };
        return Task.CompletedTask;
    }
    protected bool errorVisible;
    protected OrderDto order;

    protected IEnumerable<LookupDto> statesForStateId;


    protected int statesForStateIdCount;
    protected LookupDto statesForStateIdValue;
    protected async Task statesForStateIdLoadData(LoadDataArgs args)
    {
        try
        {
            statesForStateId = await SalesManagerClientService.GetStates();
            statesForStateIdCount = statesForStateId.Count();

        }
        catch (System.Exception ex)
        {
            NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load State" });
        }
    }
    protected async Task FormSubmit()
    {
        try
        {
            await SalesManagerClientService.CreateOrder(order);
            DialogService.Close(order);
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