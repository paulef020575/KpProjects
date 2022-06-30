using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KpProjects.Classes
{
    /// <summary>
    ///     Класс "Проект"
    /// </summary>
    public class KpProject : DataClass
    {
        #region Properties

        #region Name

        /// <summary>
        ///     Наименование
        /// </summary>
        [Required]
        [StringLength(300)]
        public override string Name { get; set; }

        #endregion

        #region Comment

        /// <summary>
        ///     Примечание
        /// </summary>
        [StringLength(int.MaxValue)]
        public string Comment { get; set; }

        #endregion

        #region HeadPerson

        /// <summary>
        ///     Идентификатор ответственного
        /// </summary>
        [Required]
        public Guid IdHeadPerson { get; set; }

        /// <summary>
        ///     Ответственный
        /// </summary>
        [ForeignKey(nameof(IdHeadPerson))]
        public virtual Person HeadPerson { get; set; }

        #endregion

        #region Date properties

        #region PlanStartDate

        /// <summary>
        ///     Плановая дата начала проекта
        /// </summary>
        [Required]
        public DateTime PlanStartDate { get; set; }

        #endregion

        #region StartDate

        /// <summary>
        ///     Фактическая дата старта работ
        /// </summary>
        public DateTime? StartDate { get; set; }

        #endregion

        #region PlanFinishDate

        /// <summary>
        ///     Плановая дата завершения работ
        /// </summary>
        public DateTime? PlanFinishDate { get; set; }

        #endregion

        #region FinishDate

        /// <summary>
        ///     Дата завершения работ
        /// </summary>
        public DateTime? FinishDate { get; set; }

        #endregion

        #endregion

        #region Members

        public ICollection<Person> Members { get; set; }

        #endregion

        #region Milestones

        /// <summary>
        ///     Этапы проекта
        /// </summary>
        public virtual ICollection<Milestone> Milestones { get; set; }

        #endregion

        #endregion
    }
}
