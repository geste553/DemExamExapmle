using System;
using System.Linq;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class ProductEditWindow : Window
    {
        private Product _product;
        private bool _isEdit;

        public ProductEditWindow(Product product)
        {
            InitializeComponent();
            _product = product;
            _isEdit = product != null;

            if (_isEdit)
            {
                TbArticle.Text = _product.Article;
                TbName.Text = _product.Name;
                TbPrice.Text = _product.Price?.ToString();
                TbQuantity.Text = _product.Count?.ToString();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    if (_isEdit)
                    {
                        var productToUpdate = db.Products.FirstOrDefault(x => x.Id == _product.Id);
                        if (productToUpdate != null)
                        {
                            productToUpdate.Article = TbArticle.Text;
                            productToUpdate.Name = TbName.Text;
                            if (short.TryParse(TbPrice.Text, out short priceVal))
                                productToUpdate.Price = priceVal;
                            else if (!string.IsNullOrWhiteSpace(TbPrice.Text))
                                productToUpdate.Price = Convert.ToInt16(TbPrice.Text);

                            if (byte.TryParse(TbQuantity.Text, out byte countVal))
                                productToUpdate.Count = countVal;
                            else if (!string.IsNullOrWhiteSpace(TbQuantity.Text))
                                productToUpdate.Count = Convert.ToByte(TbQuantity.Text);

                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        var add = new Product();
                        add.Article = TbArticle.Text;
                        add.Name = TbName.Text;
                        if (short.TryParse(TbPrice.Text, out short priceVal))
                            add.Price = priceVal;
                        else if (!string.IsNullOrWhiteSpace(TbPrice.Text))
                            add.Price = Convert.ToInt16(TbPrice.Text);

                        if (byte.TryParse(TbQuantity.Text, out byte countVal))
                            add.Count = countVal;
                        else if (!string.IsNullOrWhiteSpace(TbQuantity.Text))
                            add.Count = Convert.ToByte(TbQuantity.Text);

                        add.Eden = "шт.";

                        db.Products.Add(add);
                        db.SaveChanges();
                    }
                }
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
        }
    }
}
