using ClownOnThisSIde.Helper;
using ClownOnThisSIde.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ClownOnThisSIde.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private CollectionViewSource collectionViewSource;
        public ICollectionView collectionView => collectionViewSource.View;
        public MainViewModel()
        {
            var products = GetProduct.GetPorducts();
            ObservableCollection<NewProduct> newProducts = new ObservableCollection<NewProduct>();
            foreach (var product in products) newProducts.Add(product);

            collectionViewSource = new CollectionViewSource

            {
                Source = newProducts
            };
            collectionViewSource.Filter += Filter_item;
        }

        private string filtrText;
        public string FilterText
        {
            get => filtrText;
            set
            {
                filtrText = value;
                collectionViewSource.View.Refresh();
                OnPropertyChanged("FiltrText");

            }
        }

        private string sortText;
        public string SortText
        {
            get => sortText;
            set
            {
                sortText = value;
                collectionViewSource.SortDescriptions.Clear();

                if (sortText.Equals("Наим. по воз"))
                    collectionViewSource.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
                else if(sortText.Equals("Наим. по убыв."))
                    collectionViewSource.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Descending));
                else if (sortText.Equals("№ цеха по воз."))
                    collectionViewSource.SortDescriptions.Add(new SortDescription("PwNumber", ListSortDirection.Ascending));
                else if (sortText.Equals("№ цеха по убыв."))
                    collectionViewSource.SortDescriptions.Add(new SortDescription("PwNumber", ListSortDirection.Descending));
                else if (sortText.Equals("Мин. стоимость по воз."))
                    collectionViewSource.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
                else if (sortText.Equals("Мин. стоимость по убыв."))
                    collectionViewSource.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Descending));

                collectionViewSource.View.Refresh();
                OnPropertyChanged("SortText");
            }
        }
        public void Filter_item(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }
            NewProduct _product = e.Item as NewProduct;
            if (_product.Title.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;

            }
            else e.Accepted = false;
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
