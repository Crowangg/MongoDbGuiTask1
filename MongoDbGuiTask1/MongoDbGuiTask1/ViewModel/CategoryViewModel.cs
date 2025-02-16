﻿using Database.Entities;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace MongoDbGuiTask1.ViewModel
{
    class CategoryViewModel : ViewModelBase, IEntityViewModel
    {
        public event DocumentUpdatedEventHandler? DocumentUpdated;

        private readonly Category _category;

        private ObservableCollection<Item> items;

        public CategoryViewModel([NotNull] Category category)
        {
            _category = category;
            items = _category.Items == null ? (new()) : (new(_category.Items));
        }

        public string Id
        {
            get => _category.Id.ToString();
        }

        public string CategoryName
        {
            get => _category.CategoryName;
            set
            {
                _category.CategoryName = value;
                OnPropertyChanged(nameof(CategoryName));
                DocumentUpdated?.Invoke();
            }
        }

        public ObservableCollection<Item> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
                DocumentUpdated?.Invoke();
            }
        }

        public DbEntity GetEntity() => _category;
    }
}
