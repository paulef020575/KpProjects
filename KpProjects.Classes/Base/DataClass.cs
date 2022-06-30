using System;

namespace KpProjects.Classes
{
    /// <summary>
    ///     Базовый класс для данных
    /// </summary>
    public abstract class DataClass
    {
        #region Properties

        #region Id

        /// <summary>
        ///     Идентификатор строки
        /// </summary>
        public Guid Id { get; set; }

        #endregion

        #region Name

        /// <summary>
        ///     Наименование строки
        /// </summary>
        public abstract string Name { get; set; }

        #endregion

        #endregion

        #region ctor

        public DataClass()
        {
            Id = Guid.Empty;
        }

        #endregion

        #region Methods

        #region GetDescription

        /// <summary>
        ///     Возвращает текстовое описание строки
        /// </summary>
        /// <returns></returns>
        public virtual string GetDescription() => Name;

        #endregion

        #endregion
    }
}
