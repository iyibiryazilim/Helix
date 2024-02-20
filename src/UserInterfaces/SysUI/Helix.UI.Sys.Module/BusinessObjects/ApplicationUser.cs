using System.ComponentModel;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;

namespace Helix.UI.Sys.Module.BusinessObjects;

[MapInheritance(MapInheritanceType.ParentTable)]
[DefaultProperty(nameof(UserName))]
[NavigationItem("System Settings")] 
public class ApplicationUser : PermissionPolicyUser, ISecurityUserWithLoginInfo {

    private Department _department;
    private Position _position;
    private Employee _employee;
    private ApplicationUserType _applicationUserType;

    public ApplicationUser(Session session) : base(session) { }

    [ImmediatePostData]
    public Department Department
    {
        get => _department;
        set => SetPropertyValue(nameof(Department), ref _department, value);
    }

    [DataSourceProperty(nameof(Department))]

    public Position Position
    {
        get => _position;
        set => SetPropertyValue(nameof(Position), ref _position, value);
    }

    public Employee Employee
    {
        get => _employee;
        set => SetPropertyValue(nameof(Employee), ref _employee, value);
    }

    public ApplicationUserType ApplicationUserType
    {
        get => _applicationUserType;
        set => SetPropertyValue(nameof(ApplicationUserType), ref _applicationUserType, value);
    }


    [Association("UserAssignGroup")]
    public XPCollection<ApplicationGroup> Groups => GetCollection<ApplicationGroup>(nameof(Groups));



    [Browsable(false)]
    [Aggregated, Association("User-LoginInfo")]
    public XPCollection<ApplicationUserLoginInfo> LoginInfo {
        get { return GetCollection<ApplicationUserLoginInfo>(nameof(LoginInfo)); }
    }


    IEnumerable<ISecurityUserLoginInfo> IOAuthSecurityUser.UserLogins => LoginInfo.OfType<ISecurityUserLoginInfo>();

    ISecurityUserLoginInfo ISecurityUserWithLoginInfo.CreateUserLoginInfo(string loginProviderName, string providerUserKey) {
        ApplicationUserLoginInfo result = new ApplicationUserLoginInfo(Session);
        result.LoginProviderName = loginProviderName;
        result.ProviderUserKey = providerUserKey;
        result.User = this;
        return result;
    }
}
