using AutoMobileLibrary.DataAccess;
using AutoMobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoMobileWPFApp
{
    /// <summary>
    /// Interaction logic for WindowCarManagement.xaml
    /// </summary>
    public partial class WindowCarManagement : Window
    {
        ICarRepository carRepository;
        public WindowCarManagement(ICarRepository repository)
        {
            InitializeComponent();
            carRepository = repository;
        }

        public WindowCarManagement()
        {

        }

        private Car GetCarObject()
        {
            Car car = null;
            try
            {
                car = new Car {
                    CarId = int.Parse(txtCarId.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleasedYear = int.Parse(txtReleasedYear.Text)
                };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Get Car");
            }
            return car;
        }

        public void LoadCarList()
        {
            lvCars.ItemsSource = carRepository.GetCars();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Car");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.InsertCar(car);
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Car");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.UpdateCar(car);
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Car");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.DeleteCar(car);
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Car");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
