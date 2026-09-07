using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBudget.Models;
using MyBudget.ViewModel;

namespace MyBudget.Mappers
{
    public static class GroupOfAccountsMapper
    {


        public static void MapGroupOfAccountsToViewModel(
        GroupOfAccounts group,
        GroupOfAccountsViewModel viewModel)
        {
            viewModel.Id = group.Id;
            viewModel.GroupDescription = group.GroupDescription;
            viewModel.GroupInformation = group.GroupInformation;
        }


        public static void MapViewModelToGroupOfAccounts(
            GroupOfAccountsViewModel viewModel,
            GroupOfAccounts group)
        {
            group.Id = viewModel.Id;
            group.GroupDescription = viewModel.GroupDescription;
            group.GroupInformation = viewModel.GroupInformation;
        }
    }
}

