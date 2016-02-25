using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductInfoApp.BLL;
using ProductInfoApp.DAL.DAO;

namespace ProductInfoApp
{
    public partial class ProductUI : Form
    {
        ProductBLL aProductBll=new ProductBLL();
        public ProductUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Product aProduct = new Product();
            aProduct.Code = codeTextBox.Text;
            aProduct.Name = nameTextBox.Text;
            aProduct.Quantity = quantityTextBox.Text;

            string msg = aProductBll.Save(aProduct);

            MessageBox.Show(msg);
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            productListView.Items.Clear();
            int totalQuantity = 0;
            List<Product> products = new List<Product>();          
            products = aProductBll.GetAllProduct();         
            ListViewItem item;
            foreach (Product aProduct in products)
            {
                 totalQuantity +=Convert.ToInt32(aProduct.Quantity);       
                 item = new ListViewItem(aProduct.Code);
                 item.SubItems.Add(aProduct.Name);
                 item.SubItems.Add(aProduct.Quantity.ToString());
                 productListView.Items.Add(item);
            }
           
            showQuantityTextBox.Text = totalQuantity.ToString();
        }

      
    }
}
