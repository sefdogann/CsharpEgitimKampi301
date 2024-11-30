using CSharpEgitimKampi301Ef.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301Ef
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
         EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAverageCapacity.Text = db.Location.Average(x => x.Capacity).ToString();
            lblAveragePrice.Text = db.Location.Average(x => x.Price)?.ToString("0.00") + "₺";
            int lastCountryId = db.Location.Max(x=>x.LocationId);
            lblLastCountreyAdded.Text = db.Location.Where(x => x.LocationId==lastCountryId).Select(y=>y.Country).FirstOrDefault();
            lblCappadociaCapacity.Text = db.Location.Where(x => x.City == "Cappadocia").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTrAverageCapacity.Text = db.Location.Where(x=>x.Country=="Turkiye").Average(y=>y.Capacity).ToString();
            var romeGuideId=db.Location.Where(x=>x.City=="Rome").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuide.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblHighestCapacityTour.Text = db.Location.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMostExpensiveTour.Text = db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault().ToString();

            var guidIdByNameAnastasiaGritzfeld = db.Guide.Where(x => x.GuideName == "Anastasia" && x.GuideSurname == "Gritzfeld").Select(y => y.GuideId).FirstOrDefault();

            lblAnastasiaGritzfeldTourCount.Text = db.Location.Where(x => x.GuideId == guidIdByNameAnastasiaGritzfeld).Count().ToString(); 
        }
    }
}
