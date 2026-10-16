using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    // Типы запросов
    public enum RequestType
    {
        TypeA,
        TypeB,
        TypeC
    }

    // Запрос
    public class Request
    {
        public RequestType Type { get; }

        public Request(RequestType type)
        {
            Type = type;
        }
    }

    // Общий интерфейс обработчиков
    public interface IHandler
    {
        void SetNextHandler(IHandler nextHandler);
        void HandleRequest(Request request);
    }

    // Обработчик запросов типа A
    public class ConcreteHandlerA : IHandler
    {
        private IHandler? nextHandler;

        public void SetNextHandler(IHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public void HandleRequest(Request request)
        {
            if (request.Type == RequestType.TypeA)
            {
                Console.WriteLine("Обработчик A обработал запрос TypeA.");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine("Обработчик A передаёт запрос дальше.");
                nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine(
                    $"Запрос {request.Type} остался необработанным.");
            }
        }
    }

    // Обработчик запросов типа B
    public class ConcreteHandlerB : IHandler
    {
        private IHandler? nextHandler;

        public void SetNextHandler(IHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public void HandleRequest(Request request)
        {
            if (request.Type == RequestType.TypeB)
            {
                Console.WriteLine("Обработчик B обработал запрос TypeB.");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine("Обработчик B передаёт запрос дальше.");
                nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine(
                    $"Запрос {request.Type} остался необработанным.");
            }
        }
    }
 }
