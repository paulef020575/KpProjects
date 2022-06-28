﻿using KpProjects.Classes;
using KpProjects.WpfClient.ViewModels.Base;

namespace KpProjects.WpfClient.ViewModels
{
    public class PersonListViewModel : DataListViewModel<Person>
    {
        public override string Title => "Тест";

        public override bool IsLoading { get => true; set { } }
    }
}