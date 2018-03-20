using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameValueCollection queryString = new NameValueCollection();
            if (string.IsNullOrEmpty(CompanyId.Text))
            {
                MessageBox.Show("Please enter the Company Id");
            }
            else if (string.IsNullOrEmpty(LocationId.Text))
            {
                MessageBox.Show("Please enter the Location Id");
            }
            else if (string.IsNullOrEmpty(MakeId.Text))
            {
                MessageBox.Show("Please enter the Make Id");
            }
            else if (string.IsNullOrEmpty(ModelId.Text))
            {
                MessageBox.Show("Please enter the Model Id");
            }
            else if (string.IsNullOrEmpty(VehicleYear.Text))
            {
                MessageBox.Show("Please enter the Vehicle Year");
            }
            else if (string.IsNullOrEmpty(VehicleMileage.Text))
            {
                MessageBox.Show("Please enter the Vehicle Mileage");
            }
            else if (string.IsNullOrEmpty(EstimateKey.Text))
            {
                MessageBox.Show("Please enter the Estimate Key");
            }
            else if (string.IsNullOrEmpty(VehicleCategory1.Text))
            {
                MessageBox.Show("Please enter the Vehicle Category 1");
            }
            else if (string.IsNullOrEmpty(VehicleCategory2.Text))
            {
                MessageBox.Show("Please enter the Vehicle Category 2");
            }
            else if (string.IsNullOrEmpty(VehicleCategory3.Text))
            {
                MessageBox.Show("Please enter the Vehicle Category 3");
            }
            else if (string.IsNullOrEmpty(VehicleCategory4.Text))
            {
                MessageBox.Show("Please enter the Vehicle Category 4");
            }
            else if (string.IsNullOrEmpty(VehicleCategory5.Text))
            {
                MessageBox.Show("Please enter the Vehicle Category 5");
            }
            else if (string.IsNullOrEmpty(CustomerID.Text))
            {
                MessageBox.Show("Please enter the Customer ID");
            }
            else if (string.IsNullOrEmpty(Vin.Text))
            {
                MessageBox.Show("Please enter the Vin");
            }
            else if (string.IsNullOrEmpty(OrderId.Text))
            {
                MessageBox.Show("Please enter the Order Id");
            }
            else
            {
                queryString["ViewCheck"] = ViewCheck.Checked.ToString();
                queryString["ViewName"] = "Default";
                queryString["CompanyId"] = CompanyId.Text;
                queryString["LocationId"] = LocationId.Text;
                queryString["MakeId"] = MakeId.Text;
                queryString["ModelId"] = ModelId.Text;
                queryString["VehicleYear"] = VehicleYear.Text;
                queryString["VehicleMileage"] = VehicleMileage.Text;
                queryString["EstimateKey"] = EstimateKey.Text;
                queryString["VehicleCat1Type"] = VehicleCategory1.Text;
                queryString["VehicleCat2Type"] = VehicleCategory2.Text;
                queryString["VehicleCat3Type"] = VehicleCategory3.Text;
                queryString["VehicleCat4Type"] = VehicleCategory4.Text;
                queryString["VehicleCat5Type"] = VehicleCategory5.Text;
                queryString["CustomerID"] = CustomerID.Text;
                queryString["Vin"] = Vin.Text;
                queryString["OrderId"] = OrderId.Text;
                string URL = ConfigurationManager.AppSettings["MPIServiceURL"].ToString();
                URL += ToQueryString(queryString);
                BrowseMPI.Visible = true;
                BrowseMPI.Navigate(URL);
                BrowseMPI.Dock = DockStyle.Fill;
                groupBox1.Visible = false;
                ControlsButton.Visible = true;
            }
        }
        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return "?" + string.Join("&", array);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            BrowseMPI.Visible = false;
        }
    }
}
