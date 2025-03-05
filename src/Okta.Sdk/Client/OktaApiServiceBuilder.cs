using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RestSharp.Interceptors;

namespace Okta.Sdk.Client
{
    /// <summary>
    /// Provides a fluent builder pattern to construct service API clients.
    /// </summary>
    public class OktaApiServiceBuilder
    {   
        /// <summary>
        /// Initializes a new instance of OktaApiServiceBuilder.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <param name="serviceDescriptors">The service descriptors.</param>
        public OktaApiServiceBuilder(Type serviceType, Dictionary<Type, ServiceDescriptor> serviceDescriptors = null)
        {
            this.ServiceDescriptors = serviceDescriptors ?? new Dictionary<Type, ServiceDescriptor>();
            this.InterfaceType = serviceType;
        }

        /// <summary>
        /// Gets the service descriptors.
        /// </summary>
        protected Dictionary<Type, ServiceDescriptor> ServiceDescriptors { get; }
        
        /// <summary>
        /// Gets the interface type.
        /// </summary>
        public Type InterfaceType { get; }

        /// <summary>
        /// Gets the ServiceProvider.
        /// </summary>
        protected IServiceProvider ServiceProvider
        {
            get
            {
                ServiceCollection serviceCollection = new ServiceCollection();
                foreach (ServiceDescriptor descriptor in ServiceDescriptors.Values)
                {
                    serviceCollection.Add(descriptor);
                }

                return serviceCollection.BuildServiceProvider();
            }
        }

        /// <summary>
        /// Use the default configuration.
        /// </summary>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseDefaultConfiguration()
        {
            return UseConfiguration(svcProvider => Configuration.GetConfigurationOrDefault());
        }

        /// <summary>
        /// Use the specified configuration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseConfiguration(Configuration configuration)
        {
            return UseConfiguration(svcProvider => configuration);
        }
        
        /// <summary>
        /// Use the specified function to load the configuration.
        /// </summary>
        /// <param name="loader">The loader function.</param>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseConfiguration(Func<IServiceProvider, Configuration> loader)
        {
            ServiceDescriptors.Add(typeof(Configuration), new ServiceDescriptor(typeof(Configuration), loader, ServiceLifetime.Singleton));
            return this;
        }

        /// <summary>
        /// Use the specified token provider.
        /// </summary>
        /// <param name="tokenProvider">The token provider.</param>
        /// <param name="serviceLifetime">The service lifetime.</param>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseOAuthTokenProvider(IOAuthTokenProvider tokenProvider, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            return UseOAuthTokenProvider(svcProvider => tokenProvider, serviceLifetime);
        }

        /// <summary>
        /// Use the specified function to load the token provider.
        /// </summary>
        /// <param name="loader">The loader function.</param>
        /// <param name="serviceLifetime"></param>
        /// <returns></returns>
        public OktaApiServiceBuilder UseOAuthTokenProvider(Func<IServiceProvider, IOAuthTokenProvider> loader, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            ServiceDescriptors.Add(typeof(IOAuthTokenProvider), new ServiceDescriptor(typeof(IOAuthTokenProvider), loader, serviceLifetime));
            return this;
        }

        /// <summary>
        /// Use the specified web proxy settings.
        /// </summary>
        /// <param name="webProxy">The web proxy.</param>
        /// <param name="serviceLifetime">The service lifetime.</param>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseWebProxy(WebProxy webProxy, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            return UseWebProxy(svcProvider => webProxy, serviceLifetime);
        }
        
        /// <summary>
        /// Use the specified function to load the web proxy settings.
        /// </summary>
        /// <param name="loader">The loader function.</param>
        /// <param name="serviceLifetime">The service lifetime.</param>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseWebProxy(Func<IServiceProvider, WebProxy> loader, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            ServiceDescriptors.Add(typeof(WebProxy), new ServiceDescriptor(typeof(WebProxy), loader, serviceLifetime));
            return this;
        }

        /// <summary>
        /// Use the specified HttpMessageHandler.
        /// </summary>
        /// <param name="httpMessageHandler">The HttpMessageHandler.</param>
        /// <param name="serviceLifetime">The service lifetime.</param>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseHttpMessageHandler(HttpMessageHandler httpMessageHandler, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            return UseHttpMessageHandler(svcProvider => httpMessageHandler, serviceLifetime);
        }

        /// <summary>
        /// Use the specified function to load the HttpMessageHandler.
        /// </summary>
        /// <param name="loader">The loader function.</param>
        /// <param name="serviceLifetime">The service lifetime.</param>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseHttpMessageHandler(Func<IServiceProvider, HttpMessageHandler> loader, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            ServiceDescriptors.Add(typeof(HttpMessageHandler), new ServiceDescriptor(typeof(HttpMessageHandler), loader, serviceLifetime));
            return this;
        }

        /// <summary>
        /// Use the specified generic interceptor.
        /// </summary>
        /// <param name="serviceLifetime">The service lifetime.</param>
        /// <typeparam name="T">The concrete Interceptor type to use.</typeparam>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseInterceptor<T>(ServiceLifetime serviceLifetime = ServiceLifetime.Singleton) where T : Interceptor
        {
            ServiceDescriptors.Add(typeof(Interceptor), new ServiceDescriptor(typeof(Interceptor), typeof(T), serviceLifetime));
            return this;
        }
        
        
        /// <summary>
        /// Use the specified interceptor implementations.
        /// </summary>
        /// <param name="interceptors">The interceptors.</param>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder UseInterceptors(params Interceptor[] interceptors)
        {
            return UseInterceptors(_ => interceptors.ToList());
        }
        
        /// <summary>
        /// Use the specified function to load the list of interceptor implementations to use.
        /// </summary>
        /// <param name="loader"></param>
        /// <param name="serviceLifetime"></param>
        /// <returns></returns>
        public OktaApiServiceBuilder UseInterceptors(Func<IServiceProvider, List<Interceptor>> loader, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            ServiceDescriptors.Add(typeof(List<Interceptor>), new ServiceDescriptor(typeof(List<Interceptor>), loader, serviceLifetime));
            return this;
        }
        
        /// <summary>
        /// Use the specified generic service implementation.
        /// </summary>
        /// <param name="serviceLifetime">The service lifetime.</param>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder Use<T>(ServiceLifetime serviceLifetime = ServiceLifetime.Singleton) where T: class
        {
            Type type = InterfaceType ?? typeof(T);
            ServiceDescriptor serviceDescriptor = new ServiceDescriptor(InterfaceType ?? typeof(T), typeof(T), serviceLifetime);
            if (ServiceDescriptors.ContainsKey(type))
            {
                ServiceDescriptors[type] = serviceDescriptor;
            }
            else
            {
                ServiceDescriptors.Add(InterfaceType ?? typeof(T), serviceDescriptor);
            }
            return this;
        }

        /// <summary>
        /// Use the specified service instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <returns>OktaApiServiceBuilder</returns>
        public OktaApiServiceBuilder Use<T>(T instance)
        {
            Type type = InterfaceType ?? typeof(T);
            ServiceDescriptor serviceDescriptor = new ServiceDescriptor(InterfaceType ?? typeof(T), instance);
            if (ServiceDescriptors.ContainsKey(type))
            {
                ServiceDescriptors[type] = serviceDescriptor;
            }
            else
            {
                ServiceDescriptors.Add(InterfaceType ?? typeof(T), serviceDescriptor);
            }
            return this;
        }
        
        /// <summary>
        /// Prepare the specified generic type for a future call to Use.  Provides fluent syntax when declaring service types.
        /// </summary>
        /// <example>...
        /// For&lt;Interface&gt;().Use&lt;Type&gt;().
        /// </example>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public OktaApiServiceBuilder For<T>()
        {
            return new OktaApiServiceBuilder(typeof(T), ServiceDescriptors);
        }

        /// <summary>
        /// Gets an instance of the specified service type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>T</returns>
        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        /// <summary>
        /// Gets an instance of the specified required service.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>T</returns>
        public T GetRequiredService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
        
        /// <summary>
        /// Use the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>OktaApiServiceBuilder</returns>
        public static OktaApiServiceBuilder UseApiClientOptions(OktaApiClientOptions options)
        {
            return new OktaApiServiceBuilder(typeof(OktaApiClientOptions)).Use(options);
        }
        
        /// <summary>
        /// Build an instance of the specified API client.
        /// </summary>
        /// <typeparam name="T">The type of the API client.</typeparam>
        /// <returns>T</returns>
        /// <exception cref="ArgumentException">Thrown if the required constructor is not found for the specified API client type.</exception>
        public T BuildApi<T>()
        {
            OktaApiClientOptions options = GetOktaApiClientOptions();

            ConstructorInfo ctor = typeof(T).GetConstructor(new Type[] { typeof(OktaApiClientOptions) });
            if (ctor == null)
            {
                throw new ArgumentException($"Unable to find required constructor of specified API type: {typeof(T).Name}");
            }

            T api = (T)ctor.Invoke(new object[]{options});
            return api;
        }

        /// <summary>
        /// Gets the client options.
        /// </summary>
        /// <returns>OktaApiClientOptions</returns>
        public OktaApiClientOptions GetOktaApiClientOptions()
        {
            OktaApiClientOptions options = GetRequiredService<OktaApiClientOptions>();
            options.OAuthTokenProvider = GetService<IOAuthTokenProvider>();
            options.WebProxy = GetService<WebProxy>();
            options.HttpMessageHandler = GetService<HttpMessageHandler>();
            options.Interceptors = GetService<List<Interceptor>>();
            Interceptor singleInterceptor = GetService<Interceptor>();
            if (singleInterceptor != null)
            {
                if (options.Interceptors == null)
                {
                    options.Interceptors = new List<Interceptor>();
                }
                options.Interceptors.Add(singleInterceptor);
            }
            return options;
        }

        /// <summary>
        /// Build instances of the specified API clients.
        /// </summary>
        /// <typeparam name="T1">The first type.</typeparam>
        /// <typeparam name="T2">The second type.</typeparam>
        /// <returns>Tuple</returns>
        public Tuple<T1, T2> BuildApis<T1, T2>()
        {
            return new Tuple<T1, T2>(BuildApi<T1>(), BuildApi<T2>());
        }

        /// <summary>
        /// Build instances of the specified API clients.
        /// </summary>
        /// <typeparam name="T1">The first type.</typeparam>
        /// <typeparam name="T2">The second type.</typeparam>
        /// <typeparam name="T3">The third type.</typeparam>
        /// <returns>Tuple</returns>
        public Tuple<T1, T2, T3> BuildApis<T1, T2, T3>()
        {
            return new Tuple<T1, T2, T3>(BuildApi<T1>(), BuildApi<T2>(), BuildApi<T3>());
        }
        
        /// <summary>
        /// Build instances of the specified API clients.
        /// </summary>
        /// <typeparam name="T1">The first type.</typeparam>
        /// <typeparam name="T2">The second type.</typeparam>
        /// <typeparam name="T3">The third type.</typeparam>
        /// <typeparam name="T4">The fourth type.</typeparam>
        /// <returns>Tuple</returns>
        public Tuple<T1, T2, T3, T4> BuildApis<T1, T2, T3, T4>()
        {
            return new Tuple<T1, T2, T3, T4>(BuildApi<T1>(), BuildApi<T2>(), BuildApi<T3>(), BuildApi<T4>());
        }
        
        /// <summary>
        /// Build instances of the specified API clients.
        /// </summary>
        /// <typeparam name="T1">The first type.</typeparam>
        /// <typeparam name="T2">The second type.</typeparam>
        /// <typeparam name="T3">The third type.</typeparam>
        /// <typeparam name="T4">The fourth type.</typeparam>
        /// <typeparam name="T5">The fifth type.</typeparam>
        /// <returns>Tuple</returns>
        public Tuple<T1, T2, T3, T4, T5> BuildApis<T1, T2, T3, T4, T5>()
        {
            return new Tuple<T1, T2, T3, T4, T5>(BuildApi<T1>(), BuildApi<T2>(), BuildApi<T3>(), BuildApi<T4>(), BuildApi<T5>());
        }
        
        /// <summary>
        /// Build instances of the specified API clients.
        /// </summary>
        /// <typeparam name="T1">The first type.</typeparam>
        /// <typeparam name="T2">The second type.</typeparam>
        /// <typeparam name="T3">The third type.</typeparam>
        /// <typeparam name="T4">The fourth type.</typeparam>
        /// <typeparam name="T5">The fifth type.</typeparam>
        /// <typeparam name="T6">The sixth type.</typeparam>
        /// <returns>Tuple</returns>
        public Tuple<T1, T2, T3, T4, T5, T6> BuildApis<T1, T2, T3, T4, T5, T6>()
        {
            return new Tuple<T1, T2, T3, T4, T5, T6>(BuildApi<T1>(), BuildApi<T2>(), BuildApi<T3>(), BuildApi<T4>(), BuildApi<T5>(), BuildApi<T6>());
        }
        
        /// <summary>
        /// Build instances of the specified API clients.
        /// </summary>
        /// <typeparam name="T1">The first type.</typeparam>
        /// <typeparam name="T2">The second type.</typeparam>
        /// <typeparam name="T3">The third type.</typeparam>
        /// <typeparam name="T4">The fourth type.</typeparam>
        /// <typeparam name="T5">The fifth type.</typeparam>
        /// <typeparam name="T6">The sixth type.</typeparam>
        /// <typeparam name="T7">The seventh type.</typeparam>
        /// <returns>Tuple</returns>
        public Tuple<T1, T2, T3, T4, T5, T6, T7> BuildApis<T1, T2, T3, T4, T5, T6, T7>()
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(BuildApi<T1>(), BuildApi<T2>(), BuildApi<T3>(), BuildApi<T4>(), BuildApi<T5>(), BuildApi<T6>(), BuildApi<T7>());
        }
        
        /// <summary>
        /// Build instances of the specified API clients.
        /// </summary>
        /// <typeparam name="T1">The first type.</typeparam>
        /// <typeparam name="T2">The second type.</typeparam>
        /// <typeparam name="T3">The third type.</typeparam>
        /// <typeparam name="T4">The fourth type.</typeparam>
        /// <typeparam name="T5">The fifth type.</typeparam>
        /// <typeparam name="T6">The sixth type.</typeparam>
        /// <typeparam name="T7">The seventh type.</typeparam>
        /// <typeparam name="T8">The eigth type.</typeparam>
        /// <returns>Tuple</returns>
        public Tuple<T1, T2, T3, T4, T5, T6, T7, T8> BuildApis<T1, T2, T3, T4, T5, T6, T7, T8>()
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, T8>(BuildApi<T1>(), BuildApi<T2>(), BuildApi<T3>(), BuildApi<T4>(), BuildApi<T5>(), BuildApi<T6>(), BuildApi<T7>(), BuildApi<T8>());
        }
    }
}