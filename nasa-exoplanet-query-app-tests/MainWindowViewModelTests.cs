using System.Reflection;

namespace nasa_exoplanet_query_app {
    public class MainWindowViewModelTests {
        [Fact]
        public void CopyArrayValuesToDropDown_Produces_NotSpecified_First_And_Preserves_Others() {
            // Create instance without invoking constructor to avoid network-populating side effects
            var ctor = typeof(MainWindowViewModel).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);
            Assert.NotNull(ctor);
            var vm = (MainWindowViewModel)ctor.Invoke(null);

            var method = typeof(MainWindowViewModel).GetMethod("CopyArrayValuesToDropDown", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);

            string[] input = new[] { "Header", "Alpha", "Beta" };
            var result = (string[])method.Invoke(vm, new object[] { input })!;

            Assert.Equal(input.Length, result.Length);
            Assert.Equal(ExoPlanetDataModel.NOT_SPECIFIED, result[0]);
            Assert.Equal("Alpha", result[1]);
            Assert.Equal("Beta", result[2]);
        }
    }
}
