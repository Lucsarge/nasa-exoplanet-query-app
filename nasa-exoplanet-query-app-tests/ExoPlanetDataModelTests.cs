
namespace nasa_exoplanet_query_app {
    public class ExoPlanetDataModelTests {
        [Fact]
        public void Constructor_Sets_Defaults() {
            var model = new ExoPlanetDataModel();

            Assert.NotNull(model.DiscYearStrings);
            Assert.Single(model.DiscYearStrings);
            Assert.Equal(ExoPlanetDataModel.NOT_SPECIFIED, model.DiscYearStrings[0]);
            Assert.Equal(0, model.DiscYearSelectedIndex);

            Assert.NotNull(model.DiscMethodStrings);
            Assert.Single(model.DiscMethodStrings);
            Assert.Equal(ExoPlanetDataModel.NOT_SPECIFIED, model.DiscMethodStrings[0]);
            Assert.Equal(0, model.DiscMethodSelectedIndex);

            Assert.NotNull(model.HostNameStrings);
            Assert.Single(model.HostNameStrings);
            Assert.Equal(ExoPlanetDataModel.NOT_SPECIFIED, model.HostNameStrings[0]);
            Assert.Equal(0, model.HostNameSelectedIndex);

            Assert.NotNull(model.DiscFacilityStrings);
            Assert.Single(model.DiscFacilityStrings);
            Assert.Equal(ExoPlanetDataModel.NOT_SPECIFIED, model.DiscFacilityStrings[0]);
            Assert.Equal(0, model.DiscFacilitySelectedIndex);

            Assert.NotNull(model.ExoPlanetCollection);
            Assert.Empty(model.ExoPlanetCollection);
        }

        [Fact]
        public void SettingProperties_RaisesPropertyChanged() {
            var model = new ExoPlanetDataModel();
            int events = 0;
            var changedNames = new System.Collections.Generic.List<string>();

            model.PropertyChanged += (sender, e) => {
                events++;
                changedNames.Add(e.PropertyName);
            };

            model.DiscYearSelectedIndex = 5;
            model.DiscYearStrings = new[] { "h", "i" };
            model.DiscMethodSelectedIndex = 2;
            model.DiscMethodStrings = new[] { "m1", "m2" };
            model.HostNameSelectedIndex = 1;
            model.HostNameStrings = new[] { "a", "b" };
            model.DiscFacilitySelectedIndex = 3;
            model.DiscFacilityStrings = new[] { "f1", "f2" };
            model.ExoPlanetCollection = new System.Collections.ObjectModel.ObservableCollection<ExoPlanetData>();

            Assert.True(events >= 8);
            Assert.Contains(nameof(model.DiscYearSelectedIndex), changedNames);
            Assert.Contains(nameof(model.DiscYearStrings), changedNames);
            Assert.Contains(nameof(model.ExoPlanetCollection), changedNames);
        }
    }
}
