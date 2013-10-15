using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppIoCContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICreditCard masterCard = new MasterCard();
            //ICreditCard visaCard = new VisaCard();

            var resolver = new Resolver();

            resolver.Register<Shopper, Shopper>();
            resolver.Register<ICreditCard, VisaCard>();

            //var shopper = new Shopper(resolver.ResolveCreditCard());		
            //var shopper = new Shopper(masterCard);
            //var shopper2 = new Shopper(visaCard);

            var shopper = resolver.Resolve<Shopper>();

            shopper.Charge();
            //shopper2.Charge();

            Console.ReadKey();
        }
    }

    public class Shopper
    {
        private readonly ICreditCard _creditCard;

        public Shopper(ICreditCard creditCard)
        {
            _creditCard = creditCard;
        }

        public void Charge()
        {
            Console.WriteLine(_creditCard.Charge());
        }
    }

    public interface ICreditCard
    {
        string Charge();
    }

    public class VisaCard : ICreditCard
    {
        public string Charge()
        {
            return "I'm paying with Visa";
        }
    }

    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "I'm paying with Master";
        }
    }

    public class Resolver
    {
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type typeToResolve)
        {
            Type resolvedType = null;

            try
            {
                resolvedType = _dependencyMap[typeToResolve];
            }
            catch
            {
                //Throw an Exception
            }

            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();

            if (!constructorParameters.Any())
                return Activator.CreateInstance(resolvedType);

            IList<object> parameters = new List<object>();
            foreach (var parameterToResolve in constructorParameters)
            {
                parameters.Add(Resolve(parameterToResolve.ParameterType));
            }

            return firstConstructor.Invoke(parameters.ToArray());
        }

        public void Register<TFrom, TTo>()
        {
            _dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }

        /*
        public ICreditCard ResolveCreditCard()
        {
            if(new Random().Next(2) == 1)
            {
                return new VisaCard();
            }
		
            return new MasterCard();
        }
        */

    }
}
