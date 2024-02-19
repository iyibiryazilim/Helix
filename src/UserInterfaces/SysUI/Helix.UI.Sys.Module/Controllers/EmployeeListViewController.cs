using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Helix.UI.Sys.Module.BusinessObjects;
using Helix.UI.Sys.Module.DataStores;
using Helix.UI.Sys.Module.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix.UI.Sys.Module.Controllers
{
    
    public partial class EmployeeListViewController : ViewController<ListView>
    {
        private PopupWindowShowAction syncEmploye;
        public EmployeeListViewController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Employee);

            syncEmploye= new PopupWindowShowAction(this,nameof(syncEmploye),PredefinedCategory.View);
            syncEmploye.TargetObjectType = typeof(Employee);
            syncEmploye.TargetViewType = ViewType.ListView;


            syncEmploye.CustomizePopupWindowParams += syncEmploye_CustomizePopVindowParams;
        }

        private void syncEmploye_CustomizePopVindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace(typeof(VW_Employee));

            string listViewId = Application.FindListViewId(typeof(VW_Employee));

            CollectionSourceBase cs = Application.CreateCollectionSource(os, typeof(VW_Employee), listViewId, CollectionSourceDataAccessMode.Client, CollectionSourceMode.Normal);

            ConnectionParameter connectionParameter = View.ObjectSpace.FindObject<ConnectionParameter>(CriteriaOperator.Parse("IsActive = ?", true));

            if (connectionParameter != null)
            {
                var data = Task.Run(() => new EmployeeDataStore(connectionParameter).GetObjects());
                {
                    if (data.Result != null)
                    {
                        foreach (var item in data.Result)
                        {
                            cs.Add(item);
                        }


                    }
                }
            }

            ListView listView = Application.CreateListView(listViewId, cs, true);
            e.View = listView;

            e.DialogController.AcceptAction.Execute += EmployeeAcceptAction_Execute; ;
        }

        private void EmployeeAcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            List<Employee> selectedItems = e.SelectedObjects.OfType<Employee>().ToList();
            foreach (var item in selectedItems)
            {
                Employee employee = View.ObjectSpace.FindObject<Employee>(CriteriaOperator.Parse("ReferenceId= ?", item.ReferenceId));
                if (employee is null)
                {
                   
                    employee.Code = item.Code;
                    employee.FirstName = item.FirstName;
                    employee.RegisterCode = item.RegisterCode;
                    
                   
                }


            }
            View.ObjectSpace.CommitChanges();
            View.Refresh(true);
        }
        protected override void OnActivated()
        {
            base.OnActivated();

        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

        }
        protected override void OnDeactivated()
        {

            base.OnDeactivated();
        }
    }
}
