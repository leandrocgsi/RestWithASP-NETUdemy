namespace Api.Infrastructure.Configs
{
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Autofac.Features.Variance;
    using Container;
    using Features.Values;
    using MediatR;
    using MediatR.Pipeline;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.Extensions.DependencyInjection;
    using Validation;

    public static class AutofacConfig
    {
        public static IContainer UseAutofac(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            var builder = new ContainerBuilder();
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterAssemblyTypes(typeof(ValuesController).GetTypeInfo().Assembly).Where(t =>
                    t.GetInterfaces().Any(i => i.IsClosedTypeOf(typeof(IRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(IRequestHandler<>))
                                               || i.IsClosedTypeOf(typeof(IAsyncRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(IAsyncRequestHandler<>))
                                               || i.IsClosedTypeOf(typeof(ICancellableAsyncRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(INotificationHandler<>))
                                               || i.IsClosedTypeOf(typeof(IAsyncNotificationHandler<>))
                                               || i.IsClosedTypeOf(typeof(ICancellableAsyncNotificationHandler<>))
                    )
                )
                .AsImplementedInterfaces();

            builder.RegisterModule(new MediatorModule());

            builder.RegisterGeneric(typeof(ValidationPreProcessor<>)).As(typeof(IRequestPreProcessor<>));

            builder.Register(context =>
            {
                var urlHelperFactory = context.Resolve<IUrlHelperFactory>();
                var actionContextAccessor = context.Resolve<IActionContextAccessor>();
                return urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
            });

            builder.Populate(serviceCollection);

            return builder.Build();
        }
    }
}