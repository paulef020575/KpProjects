using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KpProjects.Classes
{
    /// <summary>
    ///     Класс "Задача"
    /// </summary>
    public class KpTask : DataClass
    {

        #region Properties

        #region Name

        [StringLength(1000)] [Required] public override string Name { get; set; }

        #endregion

        #region Description

        [StringLength(int.MaxValue)] 
        public string Description { get; set; }

        #endregion

        #region Milestone

        [Required]
        public Guid IdMilestone { get; set; }

        [ForeignKey(nameof(IdMilestone))]
        public Milestone Milestone { get; set; }

        #endregion

        #region Author

        [Required]
        public Guid IdAuthor { get; set; }

        [ForeignKey(nameof(IdAuthor))]
        public Person Author { get; set; }

        #endregion

        #region Executor 

        public Guid IdExecutor { get; set; }

        /// <summary>
        ///     Исполнитель
        /// </summary>
        [ForeignKey(nameof(IdExecutor))]
        public Person Executor { get; set; }

        #endregion

        #region Execution

        public short Execution { get; set; }

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

        #region TaskStatus

        public TaskStatusEnum TaskStatus { get; set; }

        #endregion

        #endregion
    }
}
