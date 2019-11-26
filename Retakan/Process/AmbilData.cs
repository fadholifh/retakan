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
    class AmbilData
    {
        public double mag { get; set; }
        public string place { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime time { get; set; }
        public string enteredDate { get; set; }
        public string tsunami { get; set; }
        public DateTime gener { get; set; }
        public string StrAPI { get; set; }
        public string Obj { get; set; }

        public async void AmbilDataBesar()
        {
            var StrAPI = "http://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=2&minmagnitude=7";
            var client = new HttpClient();

            Task<string> asyncData = client.GetStringAsync(StrAPI);

            try
            {
                var jsonData = await asyncData;
                var parsed = JObject.Parse(jsonData);
                var generated = (Object)parsed["metadata"];
                var upd = JsonConvert.DeserializeObject<Metadata>(generated.ToString());
                gener = upd.generated;
                //Console.WriteLine(upd.generated);
                place = (string)parsed["features"][0]["properties"]["place"];
                tsunami = (string)parsed["features"][0]["properties"]["tsunami"];
                mag = (double)parsed["features"][0]["properties"]["mag"];
                var waktu = (Object)parsed["features"][0]["properties"];
                var Obj = JsonConvert.DeserializeObject<AmbilData>(waktu.ToString());
                time = Obj.time;
                /*
                Console.WriteLine("--console--");
                Console.WriteLine(Obj.time);
                Console.WriteLine(mag);
                Console.WriteLine(place);
                Console.WriteLine(tsunami);
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine("Json Parser gagal diakses");
                Console.WriteLine("Error at : " + ex.Message);
            }
        }
        public async void AmbilDataMenengah()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
            var StrAPI = "http://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=2&minmagnitude=4&maxmagnitude=6";
            var client = new HttpClient();

            Task<string> asyncData = client.GetStringAsync(StrAPI);

            try
            {
                Console.WriteLine(StrAPI);
                var jsonData = await asyncData;
                var parsed = JObject.Parse(jsonData);
                var generated = (Object)parsed["metadata"];
                var upd = JsonConvert.DeserializeObject<Metadata>(generated.ToString());
                gener = upd.generated;
                //Console.WriteLine(upd.generated);
                place = (string)parsed["features"][0]["properties"]["place"];
                tsunami = (string)parsed["features"][0]["properties"]["tsunami"];
                mag = (double)parsed["features"][0]["properties"]["mag"];
                var waktu = (Object)parsed["features"][0]["properties"];
                var Obj = JsonConvert.DeserializeObject<AmbilData>(waktu.ToString());
                time = Obj.time;
                /*
                Console.WriteLine("--console menengah--");
                Console.WriteLine(Obj.time);
                Console.WriteLine(mag);
                Console.WriteLine(place);
                Console.WriteLine(tsunami);
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine("Json Parser gagal diakses");
                Console.WriteLine("Error at : " + ex.Message);
            }
        }
        public async void AmbilDataKecil()
        {
            var StrAPI = "http://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=2&maxmagnitude=3";
            var client = new HttpClient();

            Task<string> asyncData = client.GetStringAsync(StrAPI);

            try
            {
                var jsonData = await asyncData;
                var parsed = JObject.Parse(jsonData);
                var generated = (Object)parsed["metadata"];
                var upd = JsonConvert.DeserializeObject<Metadata>(generated.ToString());
                gener = upd.generated;
                //Console.WriteLine(upd.generated);
                place = (string)parsed["features"][0]["properties"]["place"];
                string b = (string)parsed["features"][0]["properties"]["tsunami"];
                if (b == "1")
                {
                    tsunami = "Berpotensi";
                }
                else
                {
                    tsunami = "Tidak Berpotensi";
                }
                mag = (double)parsed["features"][0]["properties"]["mag"];
                var waktu = (Object)parsed["features"][0]["properties"];
                var Obj = JsonConvert.DeserializeObject<AmbilData>(waktu.ToString());
                time = Obj.time;

                /*
                Console.WriteLine("--console menengah--");
                Console.WriteLine(Obj.time);
                Console.WriteLine(mag);
                Console.WriteLine(place);
                Console.WriteLine(tsunami);
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine("Json Parser gagal diakses");
                Console.WriteLine("Error at : " + ex.Message);
            }
        }
    }
}
