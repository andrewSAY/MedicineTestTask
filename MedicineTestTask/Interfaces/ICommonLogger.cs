using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineTestTask.Interfaces
{
    public interface ICommonLogger
    {
        /// <summary>
        /// Сбрасывает в лог информационное сообщение
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void Info(string message);
        /// <summary>
        /// Сбрасывает в лог предупреждение
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void Warning(string message);
        /// <summary>
        /// Сбрасывает в лог сообщение об ошибке
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void Error(string message);
        /// <summary>
        /// Сбрасывает в лог сообщение об ошибке вместе с информацией об исключении.
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="exception">Объект, представляющий исключение</param>
        void Error(string message, Exception exception);
    }
}
