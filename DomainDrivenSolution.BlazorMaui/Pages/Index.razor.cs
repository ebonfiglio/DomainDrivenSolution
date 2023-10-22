using DomainDrivenSolution.Logic;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenSolution.BlazorMaui.Pages
{
    public partial class Index
    {
        public SnackMachine SnackMachine { get; set; } = new();
        protected override void OnInitialized()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                SnackMachine = session.Get<SnackMachine>(1L);
            }
        }
    }
}
