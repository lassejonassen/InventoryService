﻿using FluentValidation;
using InventoryService.Application.Abstractions.Behavior;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryService.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		var assembly = typeof(DependencyInjection).Assembly;

		services.AddMediatR(configuration => {
			configuration.RegisterServicesFromAssembly(assembly);
			configuration.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
		});
		services.AddValidatorsFromAssembly(assembly);

		return services;
	}
}
