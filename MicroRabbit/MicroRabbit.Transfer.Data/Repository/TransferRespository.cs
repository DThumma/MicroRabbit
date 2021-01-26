using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Data.Respository
{
	public class TransferRespository : ITransferRepository
	{
		private TransferDbContext _ctx;
		public TransferRespository(TransferDbContext ctx)
		{
			_ctx = ctx;
		}

		public void Add(TransferLog transferLog)
		{
			_ctx.TransferLogs.Add(transferLog);
			_ctx.SaveChanges();
		}

		public IEnumerable<TransferLog> GetTransferLogs()
		{
			return _ctx.TransferLogs;
		}
	}
}
