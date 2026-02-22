using System.Reflection;

namespace nasa_exoplanet_query_app {
    public class MainWindowViewModelTests {
        [Theory]
        [InlineData()]
        [InlineData("Header", "Alpha", "Beta")]
        [InlineData("Header", "Alpha", "Beta", "Gamma", "Delta", "Epsilon")]
        [InlineData(null, null, null, null)]
        [InlineData("Header", "Alpha", null, "Gamma", "Delta", null)]
        public void CopyArrayValuesToDropDown_Produces_NotSpecified_First_And_Preserves_Others(params string[] inputStrings) {
            // Create instance without invoking constructor to avoid network-populating side effects
            // like PopulateDropdownFields() being called.
            BindingFlags ctorBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var ctor = typeof(MainWindowViewModel).GetConstructor(ctorBindingFlags, null, Type.EmptyTypes, null);
            Assert.NotNull(ctor);
            var vm = (MainWindowViewModel)ctor.Invoke(null);

            BindingFlags pvtMethodBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            var copyValuesMethod = typeof(MainWindowViewModel).GetMethod("CopyArrayValuesToDropDown", pvtMethodBindingFlags);
            Assert.NotNull(copyValuesMethod);

            var result = (string[])copyValuesMethod.Invoke(vm, new object[] { inputStrings })!;

            Assert.True(result.Length > 0); // array should have at least one element for "N/S"
            Assert.Equal(ExoPlanetDataModel.NOT_SPECIFIED, result[0]);
            for (int i = 1; i < inputStrings.Length; i++) {
                Assert.Equal(inputStrings[i], result[i]);
            }
        }
    }
}
