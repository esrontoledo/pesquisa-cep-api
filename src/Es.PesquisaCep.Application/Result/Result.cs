using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Es.PesquisaCep.Application.Result
{
    public class Result : Notifiable
    {
        /// <summary>
        /// Retorna true se não há nenhuma modificação
        /// </summary>
        public bool Success { get { return !Notifications.Any(); } }
        /// <summary>
        /// Construtor de result.
        /// </summary>
        protected Result()
        {
        }

        /// <summary>
        /// Construtor para inicializar result com notificação
        /// </summary>
        /// <param name="notification"></param>
        protected Result(Notification notification)
        {
            AddNotification(notification);
        }

        /// <summary>
        /// Método para adicionar notificações.
        /// </summary>
        /// <param name="notifications"></param>
        protected Result(IReadOnlyCollection<Notification> notifications)
        {
            AddNotifications(notifications);
        }

        /// <summary>
        /// Método para retornar OK.
        /// </summary>
        /// <returns></returns>
        public static Result Ok()
        {
            return new Result();
        }

        /// <summary>
        /// Método para retornar Error com notificações.
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        public static Result Error(IReadOnlyCollection<Notification> notifications)
        {
            return new Result(notifications);
        }

        /// <summary>
        /// Construtor inicialização result notificação de erro
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public static Result Error(Notification notification)
        {
            return new Result(notification);
        }
    }

    /// <summary>
    /// Classe Result genérica.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Notifiable where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Success { get { return !Notifications.Any(); } }
        /// <summary>
        /// 
        /// </summary>
        public T Object { get; }

        private Result(T obj)
        {
            Object = obj;
        }

        private Result(IReadOnlyCollection<Notification> notifications)
        {
            Object = null;
            AddNotifications(notifications);
        }

        private Result(Notification notification)
        {
            AddNotification(notification);
        }

        /// <summary>
        /// Retorna um resultado Ok.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result<T> Ok(T obj)
        {
            return new Result<T>(obj);
        }

        /// <summary>
        /// Retorna um erro.
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        public static Result<T> Error(IReadOnlyCollection<Notification> notifications)
        {
            return new Result<T>(notifications);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public static Result<T> Error(Notification notification)
        {
            return new Result<T>(notification);
        }
    }
}
