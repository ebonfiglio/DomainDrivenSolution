
using DomainDrivenSolution.Logic;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace DomainDrivenSolution.BlazorMaui.Shared.Components
{
    public partial class SnackMachineComponent
    {
        [Parameter]
        public SnackMachine SnackMachine { get; set; } = new SnackMachine();

        public string MoneyInTransaction => SnackMachine.MoneyInTransaction.ToString();

        private void InsertAmount(Money amount)
        {
            SnackMachine.InsertMoney(amount);
            StateHasChanged();
        }

    }
}
