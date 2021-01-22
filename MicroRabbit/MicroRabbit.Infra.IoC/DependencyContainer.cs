using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using MicroRabbit.Banking.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Data.Respository;
using MicroRabbit.Banking.Data.Context;

namespace MicroRabbit.Infra.IoC
{
	public class DependencyContainer
	{
		public static void RegisterServices(IServiceCollection services)
		{
			//Domain Bus
			services.AddTransient<IEventBus, RabbitMQBus>();

			//Application Services
			services.AddTransient<IAccountService,AccountService>();

			//Data
			services.AddTransient<IAccountRepository, AccountRespository>();
			services.AddTransient<BankingDbContext>();
		}
	}
}
