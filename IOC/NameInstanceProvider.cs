using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Factory.Factory;
using Ninject.Parameters;
using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public class NameInstanceProvider : IInstanceProvider
    {
        private IKernel kernel;

        public NameInstanceProvider(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance falls back to requesting instances without 
        /// name or constraint if none can be received otherwise.
        /// </summary>
        /// <value><c>true</c> if this instance shall fall back to requesting instances without 
        /// name or constraint if none can be received otherwise, otherwise false.</value>
        public bool Fallback { get; set; }

        /// <summary>
        /// Gets an instance for the specified method and arguments. This has been modified from the 
        /// original NInject source code to allow you to have a default object returned, or a null,
        /// if an object cannot be found in the container
        /// </summary>
        /// <param name="instanceResolver">The instance resolver.</param>
        /// <param name="methodInfo">The method info of the method that was called on the factory.</param>
        /// <param name="arguments">The arguments that were passed to the factory.</param>
        /// <returns>The newly created instance.</returns>
        public virtual object GetInstance(IInstanceResolver instanceResolver, MethodInfo methodInfo, object[] arguments)
        {
            var constructorArguments = this.GetConstructorArguments(methodInfo, arguments);
            var name = this.GetName(methodInfo, arguments);
            var constraint = this.GetConstraint(methodInfo, arguments);
            var type = this.GetType(methodInfo, arguments);

            if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();
                if (genericType == typeof(IEnumerable<>) ||
                    genericType == typeof(ICollection<>) ||
                    genericType == typeof(IList<>) ||
                    genericType == typeof(List<>))
                {
                    var argumentType = type.GetGenericArguments()[0];
                    return instanceResolver.GetAllAsList(argumentType, name, constraint, constructorArguments, this.Fallback);
                }
            }

            if (type.IsArray)
            {
                var argumentType = type.GetElementType();
                return instanceResolver.GetAllAsArray(argumentType, name, constraint, constructorArguments, this.Fallback);
            }

            var canResolveObject = (bool)this.kernel.CanResolve(type, name);

            if (canResolveObject)
            {
                return instanceResolver.Get(type, name, constraint, constructorArguments, this.Fallback);
            }
            else
            {

                var canResolveDefaultObject = (bool)this.kernel.CanResolve(type, "Default");

                if (canResolveDefaultObject)
                {
                    return instanceResolver.Get(type, "Default", constraint, constructorArguments, this.Fallback);
                }
                else
                {
                    return null;
                }

            }

        }

        /// <summary>
        /// Gets the constraint for the specified method and arguments.
        /// </summary>
        /// <param name="methodInfo">The method info of the method that was called on the factory.</param>
        /// <param name="arguments">The arguments passed to the factory.</param>
        /// <returns>The constraint that shall be used to receive an instance. Null if no constraint shall be used.</returns>
        protected virtual Func<IBindingMetadata, bool> GetConstraint(MethodInfo methodInfo, object[] arguments)
        {
            return null;
        }

        /// <summary>
        /// Gets the type that shall be created for the specified method and arguments.
        /// </summary>
        /// <param name="methodInfo">The method info of the method that was called on the factory.</param>
        /// <param name="arguments">The arguments that were passed to the factory.</param>
        /// <returns>The type that shall be created for the specified method and arguments.</returns>
        protected virtual Type GetType(MethodInfo methodInfo, object[] arguments)
        {
            return methodInfo.ReturnType;
        }

        /// <summary>
        /// Gets the name that shall be used to request an instance for the specified method and arguments. 
        /// Null if unnamed instances shall be requested.
        /// </summary>
        /// <param name="methodInfo">The method info of the method that was called on the factory.</param>
        /// <param name="arguments">The arguments that were passed to the factory.</param>
        /// <returns>The name that shall be used to request an instance for the specified method and arguments. 
        /// Null if unnamed instances shall be requested.</returns>
        protected virtual string GetName(MethodInfo methodInfo, object[] arguments)
        {
            return (string)arguments[0];
        }

        /// <summary>
        /// Gets the constructor arguments that shall be passed with the instance request.
        /// </summary>
        /// <param name="methodInfo">The method info of the method that was called on the factory.</param>
        /// <param name="arguments">The arguments that were passed to the factory.</param>
        /// <returns>The constructor arguments that shall be passed with the instance request.</returns>
        protected virtual IConstructorArgument[] GetConstructorArguments(MethodInfo methodInfo, object[] arguments)
        {
            var parameters = methodInfo.GetParameters();
            var constructorArguments = new ConstructorArgument[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                constructorArguments[i] = new ConstructorArgument(parameters[i].Name, arguments[i]);
            }

            return constructorArguments.Skip(1).ToArray();
        }
    }
}
