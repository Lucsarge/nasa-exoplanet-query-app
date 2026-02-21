namespace nasa_exoplanet_query_app {
    // Class for utilizing the Table Access Protocol (TAP) to query the Exoplanet Archive
    // Documentation here: https://exoplanetarchive.ipac.caltech.edu/docs/TAP/usingTAP.html
    // Additional reference: https://www.ivoa.net/documents/TAP/20190927/REC-TAP-1.1.html
    // Additional reference: https://www.ivoa.net/documents/ADQL/20180112/PR-ADQL-2.1-20180112.html
    public static class ExoplanetTAPHelper {
        //public static readonly string EXOPLANET_ARCHIVE_BASE_URL = "https://exoplanetarchive.ipac.caltech.edu/cgi-bin/nstedAPI/nph-nstedAPI?";
        public static readonly string PlANETARY_SYSTEMS_TABLE = "ps";

        public const string PLANET_NAME = "pl_name";
        public const string HOST_NAME = "hostname";
        public const string DISC_FACILITY = "disc_facility";
        public const string DISC_YEAR = "disc_year";
        public const string DISC_METHOD = "discoverymethod";
        public const string STAR_COUNT = "sy_snum";
        public const string PLANET_COUNT = "sy_pnum";
        public const string MOON_COUNT = "sy_mnum";

        public const string EXOPLANET_ARCHIVE_BASE_URL = "https://exoplanetarchive.ipac.caltech.edu/TAP/sync?query=";

        public const string FORMAT_CSV = "&format=csv";
        public const string FORMAT_JSON = "&format=json";

        // selectParam must be separated by comma if multiple
        // TODO: change distinct to use group by
        public static string GetPSHTTPRequestString(string selectParam = "*", string format = "") {
            string requestString = $"{EXOPLANET_ARCHIVE_BASE_URL}" +
                                   $"select+distinct+{selectParam}" +
                                   $"+from+{PlANETARY_SYSTEMS_TABLE}" +
                                   $"+order+by+{selectParam}+asc" +
                                   $"{format}";

            return requestString;
        }

        public static string GetPSFilteredResultsRequestString(string hostName, string discFacility, string discYear, string discMethod, string format = FORMAT_JSON) {
            // TODO: currently filtering for discovery year 1999, but should be dynamic based on user input
            string requestString = @$"{EXOPLANET_ARCHIVE_BASE_URL}
                                    select+{PLANET_NAME},
                                           {HOST_NAME},
                                           {DISC_FACILITY},
                                           {DISC_YEAR},
                                           {DISC_METHOD},
                                           {STAR_COUNT},
                                           {PLANET_COUNT},
                                           {MOON_COUNT}+
                                    from+{PlANETARY_SYSTEMS_TABLE}+";

            bool isFirstFilter = true;
            // append the appropriate where clauses based on the currently selected filters
            if (hostName != ExoPlanetDataModel.NOT_SPECIFIED) {
                if (isFirstFilter) {
                    isFirstFilter = false;
                    requestString += $"where+{HOST_NAME}='{hostName}'+";
                }
                else {
                    requestString += "and+";
                    requestString += $"{HOST_NAME}='{hostName}'+";
                }
            }

            if (discFacility != ExoPlanetDataModel.NOT_SPECIFIED) {
                if (isFirstFilter) {
                    isFirstFilter = false;
                    requestString += $"where+{DISC_FACILITY}='{discFacility}'+";
                }
                else {
                    requestString += "and+";
                    requestString += $"{DISC_FACILITY}='{discFacility}'+";
                }
            }

            if (discYear != ExoPlanetDataModel.NOT_SPECIFIED) {
                if (isFirstFilter) {
                    isFirstFilter = false;
                    requestString += $"where+{DISC_YEAR}='{discYear}'+";
                }
                else {
                    requestString += "and+";
                    requestString += $"{DISC_YEAR}='{discYear}'+";
                }
            }

            if (discMethod != ExoPlanetDataModel.NOT_SPECIFIED) {
                if (isFirstFilter) {
                    isFirstFilter = false;
                    requestString += $"where+{DISC_METHOD}='{discMethod}'+";
                }
                else {
                    requestString += "and+";
                    requestString += $"{DISC_METHOD}='{discMethod}'+";
                }
            }

            requestString += format; // append the file format

            return requestString;
        }

        // Builds a http request string that queries the Planetary System table for unique discovery years in ascending order
        public static string GetPSDiscYearValuesString(string format = "") {
            string requestString = EXOPLANET_ARCHIVE_BASE_URL +
                                   "select+distinct+disc_year+from+ps+order+by+disc_year+asc";

            if (!String.IsNullOrEmpty(format)) {
                requestString += format;
            }

            return requestString;
        }
    }
}
