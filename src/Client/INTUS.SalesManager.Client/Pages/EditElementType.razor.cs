using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Client.Pages;

public partial class EditElementType
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
        elementType = await SalesManagerClientService.GetElementTypeById(id:Id);
    }

    protected bool errorVisible;
    protected LookupDto elementType;

    protected async Task FormSubmit()
    {
        try
        {
            await SalesManagerClientService.UpdateElementType(elementType);
            DialogService.Close(elementType);
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