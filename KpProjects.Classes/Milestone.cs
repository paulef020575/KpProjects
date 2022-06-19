using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KpProjects.Classes
{
    /// <summary>
    ///     Класс "Этап проекта"
    /// </summary>
    public class Milestone : DataClass
    {
        #region Properties

        #region Name

        /// <inheritdoc />
        [Required]
        [StringLength(300)]
        public override string Name { get; set; }

        #endregion

        #region Comment

        [StringLength(int.MaxValue)]
        public string Comment { get; set; }

        #endregion

        #region Project

        [Required]
        public Guid IdProject { get; set; }

        /// <summary>
        ///     Проект
        /// </summary>
        [ForeignKey(nameof(IdProject))]
        public virtual KpProject Project { get; set; }

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

        #region Tasks

        public ICollection<KpTask> Tasks { get; set; }

        #endregion

        #endregion
    }
}
