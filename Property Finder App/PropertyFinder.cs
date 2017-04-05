using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Property_Finder_App
{
    public partial class PropertyFinder : Form
    {
        public PropertyFinder()
        {
            InitializeComponent();

            var search = new Search();
            bindingSource.DataSource = search.Locations.Keys.ToList();
            locationComboBox.DataSource = bindingSource.DataSource;

            bindingSource.DataSource = search.PropertyTypes.Keys.ToList();
            propertyTypeComboBox.DataSource = bindingSource.DataSource;

            bindingSource.DataSource = search.Beds.Keys.ToList();
            minBedsComboBox.DataSource = bindingSource.DataSource;

            bindingSource.DataSource = search.Beds.Keys.ToList();
            maxBedsComboBox.DataSource = bindingSource.DataSource;

            var priceValues = search.Prices.Values.ToList();
            var minPrices = new List<string>();
            var maxPrices = new List<string>();

            foreach (var price in priceValues)
            {
                if (price != "0")
                {
                    minPrices.Add(price);
                    maxPrices.Add(price);
                }
            }

            bindingSource.DataSource = minPrices;
            minPriceComboBox.DataSource = bindingSource.DataSource;

            bindingSource.DataSource = maxPrices;
            maxPriceComboBox.DataSource = bindingSource.DataSource;

            propertyListView.View = View.Details;
            propertyListView.GridLines = true;
            propertyListView.FullRowSelect = true;

            //Add column header
            propertyListView.Columns.Add("Address");
            propertyListView.Columns.Add("Price");
            propertyListView.Columns.Add("Property type");
            propertyListView.Columns.Add("Beds");
            propertyListView.Columns.Add("Bathrooms");
            propertyListView.Columns.Add("Land size");
            propertyListView.Columns.Add("Car spaces");
            propertyListView.Columns.Add("Price per m2");
            propertyListView.Columns.Add("Distance from city");
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var search = new Search();
            var propertyType = Search.PropertyType.House;
            var minBeds = Search.Bed.Three;
            var minLand = 0;
            var minPrice = Search.Price.TwoHundredAndFiftyThousand;
            var maxPrice = Search.Price.ThreeHundredThousand;
            var location = Search.Location.BrisbaneGreaterRegion;
            var constructionType = Search.ConstructionType.EstablishedProperty;
            var minCarSpaces = Search.CarSpace.TwoPlus;
            var minBathrooms = Search.Bathroom.TwoPlus;
            var maxBeds = Search.Bed.Four;
            var isIncludingSurroundingSuburbs = true;
            var isExcludingPropertiesUnderContract = true;

            search.Set(propertyType, minBeds, minLand, minPrice, maxPrice, location, constructionType, minCarSpaces, minBathrooms, maxBeds, isIncludingSurroundingSuburbs, isExcludingPropertiesUnderContract);
            search.GenerateUrl();

            var listing = new Listing(search.Url);
            PopulatePropertyListView(listing.Properties);
        }

        private void PopulatePropertyListView(List<Property> properties)
        {
            foreach (var property in properties)
            {
                var listViewItem = new ListViewItem(new string[]
                {
                    property.Address.ToString(),
                    property.Price.ToString(),
                    property.PropertyType.ToString(),
                    property.Bedrooms.ToString(),
                    property.Bathrooms.ToString(),
                    property.LandSize.ToString(),
                    property.CarSpaces.ToString(),
                    property.PricePerSquareMetre.ToString(),
                    property.DistanceFromCity.ToString(),
                });

                propertyListView.Items.Add(listViewItem);
            }
        }
    }
}
