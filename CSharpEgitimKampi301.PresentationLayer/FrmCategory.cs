using CSharpEgitimKampi.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpEgitimKampi301.EntityLayer.Concrete;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class Form1 : Form
    {
        private readonly ICategoryService _categoryService;

        public Form1()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetall();
            dataGridView1.DataSource = categoryValues;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryID =int.Parse( txtCategoryID.Text);
            category.CategoryStatus = radioActive.Checked;
            category.CategoryStatus = radioPassive.Checked;
            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme Başarılı!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            var deletedValues =_categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Silme Başarılı!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Category category= new Category();
            int updatedId = int.Parse(txtCategoryID.Text) ;
            var updatedValue = _categoryService.TGetById(updatedId);
            updatedValue.CategoryName = txtCategoryName.Text;
            updatedValue.CategoryStatus = true;
            _categoryService.TUpdate(updatedValue);

        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            var value = _categoryService.TGetById(id);
            dataGridView1 .DataSource = value;
            MessageBox.Show("ID'ye göre getirildi!");
        }
    }
}
