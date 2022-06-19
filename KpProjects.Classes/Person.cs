using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KpProjects.Classes
{
    /// <summary>
    ///     Класс "Сотрудник"
    /// </summary>
    public class Person : DataClass
    {
        #region Properties

        #region Lastname

        /// <summary>
        ///     Фамилия
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Lastname { get; set; }

        #endregion

        #region Firstname

        /// <summary>
        ///     Имя
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }

        #endregion

        #region Secondname

        /// <summary>
        ///     Отчество
        /// </summary>
        [StringLength(100)]
        public string Secondname { get; set; }

        #endregion

        #region Name

        /// <summary>
        ///     Краткое имя
        /// </summary>
        [NotMapped]
        public override string Name 
        {
            get
            {
                string result = Lastname;
                if (!string.IsNullOrEmpty(Firstname))
                {
                    result += $" {Firstname[0]}.";

                    if (!string.IsNullOrEmpty(Secondname))
                        result += $" {Secondname[0]}.";
                }

                return result;
            }

            set { }
        }

        #endregion

        #region Birthday

        /// <summary>
        ///     День рождения
        /// </summary>
        public DateTime Birthday { get; set; }

        #endregion

        #region Projects 

        /// <summary>
        ///     Возглавляемые проекты
        /// </summary>
        public virtual ICollection<KpProject> Projects { get; set; }

        #endregion

        #region MemberOf

        public ICollection<KpProject> ProjectMembers { get; set; }

        #endregion

        #region AuthorOf

        [InverseProperty(nameof(KpTask.Author))]
        public ICollection<KpTask> Tasks { get; set; }

        #endregion

        #region ExecutorTasks

        [InverseProperty(nameof(KpTask.Executor))]
        public ICollection<KpTask> ExecutionTasks { get; set; }

        #endregion

        #endregion
    }
}
