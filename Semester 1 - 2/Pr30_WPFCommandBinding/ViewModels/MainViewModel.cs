using Pr30_WPFCommandBinding.Commands;
using Pr30_WPFCommandBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pr30_WPFCommandBinding.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ProductRepo productRepo = new ProductRepo();

        public ObservableCollection<ProductViewModel> ProductVM { get; set; } = new ObservableCollection<ProductViewModel>();

        public ICommand NewCmd { get; set; } = new NewProduct();
        public ICommand DeleteCmd { get; set; } = new DeleteProduct();

        public MainViewModel()
        {
            foreach (Product product in productRepo.GetAll())
            {
                ProductViewModel currentProductVM = new ProductViewModel(product);
                ProductVM.Add(currentProductVM);
            }
        }

        public void AddProduct()
        {
            // Creates a product
            Product product = new Product("Specify Name", "", 0);
            productRepo.Add(product);

            // Updates the view model so the UI matches
            ProductViewModel productViewModel = new ProductViewModel(product);
            ProductVM.Add(productViewModel);

            // Selects the new created product
            SelectedProduct = productViewModel;
        }

        public void DeleteSelectedProduct()
        {
            if (SelectedProduct != null)
            {
                SelectedProduct.DeletePerson(productRepo);
                ProductVM.Remove(SelectedProduct);
                // SelectedPerson = PersonsVM.LastOrDefault();
            }
        }

        private ProductViewModel _selectedProduct;
        public ProductViewModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value; OnPropertyChanged("SelectedProduct");

                // Another method to achieve the same result as above
                // _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}