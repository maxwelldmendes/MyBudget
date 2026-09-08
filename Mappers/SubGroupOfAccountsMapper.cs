
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.Models;
using MyBudget.ViewModel;
using MyBudget.Data;

namespace MyBudget.Mappers
{
    public class SubGroupOfAccountsMapper
    {
        public static void MapSubGroupOfAccountsToViewModel(
        SubGroupOfAccounts subGroup,
        SubGroupOfAccountsViewModel subGroupVM)
        {
            if (subGroup == null)
                throw new ArgumentNullException(nameof(subGroup));

            if (subGroupVM == null)
                throw new ArgumentNullException(nameof(subGroupVM));

            subGroupVM.Id = subGroup.Id;
            subGroupVM.SubGroupDescription = subGroup.SubGroupDescription;
            subGroupVM.GroupId = subGroup.GroupId;

            subGroupVM.GroupOfAccountsVM.Id = subGroup.GroupOfAccounts.Id;
            subGroupVM.GroupOfAccountsVM.GroupDescription = subGroup.GroupOfAccounts.GroupDescription;
            subGroupVM.GroupOfAccountsVM.GroupInformation = subGroup.GroupOfAccounts.GroupInformation;
        }


        public static void MapViewModelToSubGroupOfAccounts(
            SubGroupOfAccountsViewModel subGroupVM,
            SubGroupOfAccounts subGroup)
        {
            if (subGroup == null)
                throw new ArgumentNullException(nameof(subGroup));

            if (subGroupVM == null)
                throw new ArgumentNullException(nameof(subGroupVM));

            subGroup.Id = subGroupVM.Id;
            subGroup.SubGroupDescription = subGroupVM.SubGroupDescription;
            subGroup.GroupId = subGroupVM.GroupId;
            //subGroup.GroupOfAccounts.Id = subGroupVM.groupOfAccounts.Id;
            //subGroup.GroupOfAccounts.GroupDescription = subGroupVM.groupOfAccounts.GroupDescription;
            //subGroup.GroupOfAccounts.GroupInformation = subGroupVM.groupOfAccounts.GroupInformation;
        }
    }
}