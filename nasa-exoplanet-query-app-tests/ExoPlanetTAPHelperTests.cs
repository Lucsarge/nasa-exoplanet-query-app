using System.Text.RegularExpressions;

namespace nasa_exoplanet_query_app {
    public class ExoplanetTAPHelperTests {
        private static string Compact(string s) => Regex.Replace(s ?? string.Empty, @"\s+", "");

        [Fact]
        public void GetPSHTTPRequestString_Constructs_SelectDistinct_OrderBy_And_Format() {
            string result = ExoplanetTAPHelper.GetPSUniqueColumnValuesRequestString(ExoplanetTAPHelper.HOST_NAME, ExoplanetTAPHelper.FORMAT_CSV);

            string compact = Compact(result);
            Assert.Contains($"select+distinct+{ExoplanetTAPHelper.HOST_NAME}", compact);
            Assert.Contains($"+from+{ExoplanetTAPHelper.PlANETARY_SYSTEMS_TABLE}", compact);
            Assert.Contains($"+order+by+{ExoplanetTAPHelper.HOST_NAME}+asc", compact);
            Assert.EndsWith(ExoplanetTAPHelper.FORMAT_CSV, result);
        }

        [Fact]
        public void GetPSFilteredResultsRequestString_NoFilters_ProducesNoWhereClause() {
            string ns = ExoPlanetDataModel.NOT_SPECIFIED;
            string result = ExoplanetTAPHelper.GetPSFilteredResultsRequestString(ns, ns, ns, ns);
            Assert.True(result != null || result != string.Empty);

            string compact = Compact(result);
            // ensure select fields are present
            Assert.Contains($"select+" +
                            $"{ExoplanetTAPHelper.PLANET_NAME}," +
                            $"{ExoplanetTAPHelper.HOST_NAME}," +
                            $"{ExoplanetTAPHelper.DISC_FACILITY}," +
                            $"{ExoplanetTAPHelper.DISC_YEAR}," +
                            $"{ExoplanetTAPHelper.DISC_METHOD}," +
                            $"{ExoplanetTAPHelper.STAR_COUNT}," +
                            $"{ExoplanetTAPHelper.PLANET_COUNT}," +
                            $"{ExoplanetTAPHelper.MOON_COUNT}+", compact);
            Assert.DoesNotContain("where", compact); // ensure there is no 'where' clause when all are NOT_SPECIFIED
            Assert.EndsWith(ExoplanetTAPHelper.FORMAT_JSON, result);
        }

        [Fact]
        public void GetPSFilteredResultsRequestString_WithFilters_AppendsWhereAndAndCorrectly() {
            string host = "HOST1";
            string facility = "FAC1";
            string year = "2000";
            string method = "Transit";

            string result = ExoplanetTAPHelper.GetPSFilteredResultsRequestString(host, facility, year, method, ExoplanetTAPHelper.FORMAT_JSON);
            string compact = Compact(result);

            Assert.Contains($"where+{ExoplanetTAPHelper.HOST_NAME}='{host}'+", compact);
            Assert.Contains($"and+{ExoplanetTAPHelper.DISC_FACILITY}='{facility}'+", compact);
            Assert.Contains($"and+{ExoplanetTAPHelper.DISC_YEAR}='{year}'+", compact);
            Assert.Contains($"and+{ExoplanetTAPHelper.DISC_METHOD}='{method}'+", compact);
            Assert.EndsWith(ExoplanetTAPHelper.FORMAT_JSON, result);
        }
    }
}
