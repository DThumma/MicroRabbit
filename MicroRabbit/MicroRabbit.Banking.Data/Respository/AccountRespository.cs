using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Data.Respository
{
	public class AccountRespository : IAccountRepository
	{
		private BankingDbContext _ctx;
		public AccountRespository(BankingDbContext ctx)
		{
			_ctx = ctx;
		}
		public IEnumerable<Account> GetAccounts()
		{
			return _ctx.Accounts;
		}
	}
}
