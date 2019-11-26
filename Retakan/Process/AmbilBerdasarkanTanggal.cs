using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Data.SqlClient;

namespace Retakan.Process
{
    public class Metadata
    {
        [JsonProperty(PropertyName = "generated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime generated { get; set; }
        public string url { get; set; }
        public string title { get; set; }

        public int count { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
    class AmbilBerdasarkanTanggal
    {
        public double mag { get; set; }
        public string place { get; set; }
        public DateTime time { get; set; }
        public string tsunami { get; set; }
        public double mag1 { get; set; }
        public string place1 { get; set; }
        public DateTime time1 { get; set; }
        public string tsunami1 { get; set; }
        public double mag2 { get; set; }
        public string place2 { get; set; }
        public DateTime time2 { get; set; }
        public string tsunami2 { get; set; }
        public double mag3 { get; set; }
        public string place3 { get; set; }
        public DateTime time3 { get; set; }
        public string tsunami3 { get; set; }
        public double mag4 { get; set; }
        public string place4 { get; set; }
        public DateTime time4 { get; set; }
        public string tsunami4 { get; set; }
        public double mag5 { get; set; }
        public string place5 { get; set; }
        public DateTime time5 { get; set; }
        public string tsunami5 { get; set; }
        public double mag6 { get; set; }
        public string place6 { get; set; }
        public DateTime time6 { get; set; }
        public string tsunami6 { get; set; }
        public double mag7 { get; set; }
        public string place7 { get; set; }
        public DateTime time7 { get; set; }
        public string tsunami7 { get; set; }
        public double mag8 { get; set; }
        public string place8 { get; set; }
        public DateTime time8 { get; set; }
        public string tsunami8 { get; set; }
        public double mag9 { get; set; }
        public string place9 { get; set; }
        public DateTime time9 { get; set; }
        public string tsunami9 { get; set; }
        public DateTime gener { get; set; }
        public string StrAPI { get; set; }
        public string Obj { get; set; }

        public async void AmbilBerdasarkanTanggalBase(string d)
        {
            string Date = d;
            if (Date == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                var StrAPI = "http://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=10";
                Console.WriteLine(StrAPI);
                var client = new HttpClient();

                Task<string> asyncData = client.GetStringAsync(StrAPI);
                try
                {
                    var jsonData = await asyncData;
                    var parsed = JObject.Parse(jsonData);
                    var generated = (Object)parsed["metadata"];
                    
                    place = (string)parsed["features"][0]["properties"]["place"];
                    tsunami = (string)parsed["features"][0]["properties"]["tsunami"];
                    mag = (double)parsed["features"][0]["properties"]["mag"];
                    var waktu = (Object)parsed["features"][0]["properties"];
                    var Obj = JsonConvert.DeserializeObject<AmbilData>(waktu.ToString());
                    time = Obj.time;

                    place1 = (string)parsed["features"][1]["properties"]["place"];
                    tsunami1 = (string)parsed["features"][1]["properties"]["tsunami"];
                    mag1 = (double)parsed["features"][1]["properties"]["mag"];
                    var waktu1 = (Object)parsed["features"][1]["properties"];
                    var Obj1 = JsonConvert.DeserializeObject<AmbilData>(waktu1.ToString());
                    time1 = Obj1.time;

                    place2 = (string)parsed["features"][2]["properties"]["place"];
                    tsunami2 = (string)parsed["features"][2]["properties"]["tsunami"];
                    mag2 = (double)parsed["features"][2]["properties"]["mag"];
                    var waktu2 = (Object)parsed["features"][2]["properties"];
                    var Obj2 = JsonConvert.DeserializeObject<AmbilData>(waktu2.ToString());
                    time2 = Obj2.time;

                    place3 = (string)parsed["features"][3]["properties"]["place"];
                    tsunami3 = (string)parsed["features"][3]["properties"]["tsunami"];
                    mag3 = (double)parsed["features"][3]["properties"]["mag"];
                    var waktu3 = (Object)parsed["features"][3]["properties"];
                    var Obj3 = JsonConvert.DeserializeObject<AmbilData>(waktu3.ToString());
                    time3 = Obj3.time;

                    place4 = (string)parsed["features"][4]["properties"]["place"];
                    tsunami4 = (string)parsed["features"][4]["properties"]["tsunami"];
                    mag4 = (double)parsed["features"][4]["properties"]["mag"];
                    var waktu4 = (Object)parsed["features"][4]["properties"];
                    var Obj4 = JsonConvert.DeserializeObject<AmbilData>(waktu4.ToString());
                    time4 = Obj4.time;

                    place5 = (string)parsed["features"][5]["properties"]["place"];
                    tsunami5 = (string)parsed["features"][5]["properties"]["tsunami"];
                    mag5 = (double)parsed["features"][5]["properties"]["mag"];
                    var waktu5 = (Object)parsed["features"][5]["properties"];
                    var Obj5 = JsonConvert.DeserializeObject<AmbilData>(waktu5.ToString());
                    time5 = Obj5.time;

                    place6 = (string)parsed["features"][6]["properties"]["place"];
                    tsunami6 = (string)parsed["features"][6]["properties"]["tsunami"];
                    mag6 = (double)parsed["features"][6]["properties"]["mag"];
                    var waktu6 = (Object)parsed["features"][6]["properties"];
                    var Obj6 = JsonConvert.DeserializeObject<AmbilData>(waktu6.ToString());
                    time6 = Obj6.time;

                    place7 = (string)parsed["features"][7]["properties"]["place"];
                    tsunami7 = (string)parsed["features"][7]["properties"]["tsunami"];
                    mag7 = (double)parsed["features"][7]["properties"]["mag"];
                    var waktu7 = (Object)parsed["features"][7]["properties"];
                    var Obj7 = JsonConvert.DeserializeObject<AmbilData>(waktu7.ToString());
                    time7 = Obj7.time;

                    place8 = (string)parsed["features"][8]["properties"]["place"];
                    tsunami8 = (string)parsed["features"][8]["properties"]["tsunami"];
                    mag8 = (double)parsed["features"][8]["properties"]["mag"];
                    var waktu8 = (Object)parsed["features"][8]["properties"];
                    var Obj8 = JsonConvert.DeserializeObject<AmbilData>(waktu8.ToString());
                    time8 = Obj8.time;

                    place9 = (string)parsed["features"][9]["properties"]["place"];
                    tsunami9 = (string)parsed["features"][9]["properties"]["tsunami"];
                    mag9 = (double)parsed["features"][9]["properties"]["mag"];
                    var waktu9 = (Object)parsed["features"][9]["properties"];
                    var Obj9 = JsonConvert.DeserializeObject<AmbilData>(waktu9.ToString());
                    time9 = Obj9.time;

                    Console.WriteLine("--console menengah--");
                    Console.WriteLine(Obj1.time);
                    Console.WriteLine(mag1);
                    Console.WriteLine(place1);
                    Console.WriteLine(tsunami1);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Json Parser gagal diakses");
                    Console.WriteLine("Error at : " + ex.Message);
                }
            }
            else
            {
                var StrAPI = "http://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=10&endtime=" + Date + "";
                Console.WriteLine(StrAPI);
                var client = new HttpClient();

                Task<string> asyncData = client.GetStringAsync(StrAPI);
                try
                {
                    var jsonData = await asyncData;
                    var parsed = JObject.Parse(jsonData);
                    Console.WriteLine(StrAPI);
                    place = (string)parsed["features"][0]["properties"]["place"];
                    tsunami = (string)parsed["features"][0]["properties"]["tsunami"];
                    mag = (double)parsed["features"][0]["properties"]["mag"];
                    var waktu = (Object)parsed["features"][0]["properties"];
                    var Obj = JsonConvert.DeserializeObject<AmbilData>(waktu.ToString());
                    time = Obj.time;

                    place1 = (string)parsed["features"][1]["properties"]["place"];
                    tsunami1 = (string)parsed["features"][1]["properties"]["tsunami"];
                    mag1 = (double)parsed["features"][1]["properties"]["mag"];
                    var waktu1 = (Object)parsed["features"][1]["properties"];
                    var Obj1 = JsonConvert.DeserializeObject<AmbilData>(waktu1.ToString());
                    time1 = Obj1.time;

                    place2 = (string)parsed["features"][2]["properties"]["place"];
                    tsunami2 = (string)parsed["features"][2]["properties"]["tsunami"];
                    mag2 = (double)parsed["features"][2]["properties"]["mag"];
                    var waktu2 = (Object)parsed["features"][2]["properties"];
                    var Obj2 = JsonConvert.DeserializeObject<AmbilData>(waktu2.ToString());
                    time2 = Obj2.time;

                    place3 = (string)parsed["features"][3]["properties"]["place"];
                    tsunami3 = (string)parsed["features"][3]["properties"]["tsunami"];
                    mag3 = (double)parsed["features"][3]["properties"]["mag"];
                    var waktu3 = (Object)parsed["features"][3]["properties"];
                    var Obj3 = JsonConvert.DeserializeObject<AmbilData>(waktu3.ToString());
                    time3 = Obj3.time;

                    place4 = (string)parsed["features"][4]["properties"]["place"];
                    tsunami4 = (string)parsed["features"][4]["properties"]["tsunami"];
                    mag4 = (double)parsed["features"][4]["properties"]["mag"];
                    var waktu4 = (Object)parsed["features"][4]["properties"];
                    var Obj4 = JsonConvert.DeserializeObject<AmbilData>(waktu4.ToString());
                    time4 = Obj4.time;

                    place5 = (string)parsed["features"][5]["properties"]["place"];
                    tsunami5 = (string)parsed["features"][5]["properties"]["tsunami"];
                    mag5 = (double)parsed["features"][5]["properties"]["mag"];
                    var waktu5 = (Object)parsed["features"][5]["properties"];
                    var Obj5 = JsonConvert.DeserializeObject<AmbilData>(waktu5.ToString());
                    time5 = Obj5.time;

                    place6 = (string)parsed["features"][6]["properties"]["place"];
                    tsunami6 = (string)parsed["features"][6]["properties"]["tsunami"];
                    mag6 = (double)parsed["features"][6]["properties"]["mag"];
                    var waktu6 = (Object)parsed["features"][6]["properties"];
                    var Obj6 = JsonConvert.DeserializeObject<AmbilData>(waktu6.ToString());
                    time6 = Obj6.time;

                    place7 = (string)parsed["features"][7]["properties"]["place"];
                    tsunami7 = (string)parsed["features"][7]["properties"]["tsunami"];
                    mag7 = (double)parsed["features"][7]["properties"]["mag"];
                    var waktu7 = (Object)parsed["features"][7]["properties"];
                    var Obj7 = JsonConvert.DeserializeObject<AmbilData>(waktu7.ToString());
                    time7 = Obj7.time;

                    place8 = (string)parsed["features"][8]["properties"]["place"];
                    tsunami8 = (string)parsed["features"][8]["properties"]["tsunami"];
                    mag8 = (double)parsed["features"][8]["properties"]["mag"];
                    var waktu8 = (Object)parsed["features"][8]["properties"];
                    var Obj8 = JsonConvert.DeserializeObject<AmbilData>(waktu8.ToString());
                    time8 = Obj8.time;

                    place9 = (string)parsed["features"][9]["properties"]["place"];
                    tsunami9 = (string)parsed["features"][9]["properties"]["tsunami"];
                    mag9 = (double)parsed["features"][9]["properties"]["mag"];
                    var waktu9 = (Object)parsed["features"][9]["properties"];
                    var Obj9 = JsonConvert.DeserializeObject<AmbilData>(waktu9.ToString());
                    time9 = Obj9.time;


                    Console.WriteLine("--console menengah--");
                    Console.WriteLine(Obj.time);
                    Console.WriteLine(mag);
                    Console.WriteLine(place);
                    Console.WriteLine(tsunami);
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Json Parser gagal diakses");
                    Console.WriteLine("Error at : " + ex.Message);
                }
            }
        }
    }
}
