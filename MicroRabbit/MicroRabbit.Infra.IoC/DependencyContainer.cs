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
using MediatR;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Data.Respository;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.EventHandlers;

namespace MicroRabbit.Infra.IoC
{
	public class DependencyContainer
	{
		public static void RegisterServices(IServiceCollection services)
		{
			//Domain Bus
			services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
			{
				var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
				return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
			});


			//Subscriptions
			services.AddTransient<TransferEventHandler>();

			//DOmain Events
			services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

			//Domain Commands
			services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

			//Application Services
			services.AddTransient<IAccountService,AccountService>();
			services.AddTransient<ITransferService, TransferService>();

			//Data
			services.AddTransient<IAccountRepository, AccountRespository>();
			services.AddTransient<ITransferRepository, TransferRespository>();
			services.AddTransient<BankingDbContext>();
			services.AddTransient<TransferDbContext>();
		}
	}
}
