using System.Text.RegularExpressions;

namespace nasa_exoplanet_query_app {
    public class ExoplanetTAPHelperTests {
        private static string Compact(string s) => Regex.Replace(s ?? string.Empty, @"\s+", "");

        [Fact]
        public void GetPSHTTPRequestString_Constructs_SelectDistinct_OrderBy_And_Format() {
            string result = ExoplanetTAPHelper.GetPSHTTPRequestString(ExoplanetTAPHelper.HOST_NAME, ExoplanetTAPHelper.FORMAT_CSV);

            string compact = Compact(result);
            Assert.Contains("select+distinct+hostname", compact);
            Assert.Contains("+from+ps", compact);
            Assert.Contains("+order+by+hostname+asc", compact);
            Assert.EndsWith(ExoplanetTAPHelper.FORMAT_CSV, result);
        }

        [Fact]
        public void GetPSFilteredResultsRequestString_NoFilters_ProducesSelectAndFormat() {
            string ns = ExoPlanetDataModel.NOT_SPECIFIED;
            string result = ExoplanetTAPHelper.GetPSFilteredResultsRequestString(ns, ns, ns, ns);

            string compact = Compact(result);
            Assert.Contains("select+pl_name,", compact); // ensure select fields are present
            Assert.DoesNotContain("where+", compact); // ensure there is no 'where' clause when all are NOT_SPECIFIED
            Assert.EndsWith(ExoplanetTAPHelper.FORMAT_JSON, result);
        }

        [Fact]
        public void GetPSFilteredResultsRequestString_WithFilters_AppendsWhereAndAndCorrectly() {
            string host = "HOST1";
            string facility = "FAC1";
            string year = "2000";
            string method = "Transit";

            string result = ExoplanetTAPHelper.GetPSFilteredResultsRequestString(host, facility, year, method, "&format=csv");
            string compact = Compact(result);

            Assert.Contains($"where+{ExoplanetTAPHelper.HOST_NAME}='{host}'+", compact);
            Assert.Contains($"and+{ExoplanetTAPHelper.DISC_FACILITY}='{facility}'+", compact);
            Assert.Contains($"and+{ExoplanetTAPHelper.DISC_YEAR}='{year}'+", compact);
            Assert.Contains($"and+{ExoplanetTAPHelper.DISC_METHOD}='{method}'+", compact);
            Assert.EndsWith("&format=csv", result);
        }

        [Fact]
        public void GetPSDiscYearValuesString_AppendsFormatWhenProvided() {
            string baseResult = ExoplanetTAPHelper.GetPSDiscYearValuesString();
            Assert.Contains("select+distinct+disc_year+from+ps+order+by+disc_year+asc", Compact(baseResult));

            string withFormat = ExoplanetTAPHelper.GetPSDiscYearValuesString("&format=csv");
            Assert.EndsWith("&format=csv", withFormat);
        }
    }
}
