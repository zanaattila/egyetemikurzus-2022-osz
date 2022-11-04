using Reflection.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Reflection.Commands
{
    internal class WriteXmlJsonCommand : IConsoleCommand
    {
        public string Name => "XmlJson";

        public void Execute()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Data));
            
            Data data = new Data
            {
                Name = "Árvíztűrő tükörfúrógép",
                Id = 42
            };

            using (var stream = File.Create(Path.Combine(AppContext.BaseDirectory, "test.xml")))
            {
                xs.Serialize(stream, data);
            }

            using (var readStream = File.OpenRead(Path.Combine(AppContext.BaseDirectory, "test.xml")))
            {
                //Data? readed = xs.Deserialize(readStream) as Data;
                if (xs.Deserialize(readStream) is Data readed)
                {
                    Console.WriteLine(data == readed);
                }
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };

            var @string = JsonSerializer.Serialize<Data>(data, options);

            var data2 = JsonSerializer.Deserialize<Data>(@string, options);

            Console.WriteLine(data == data2);
        }

    }
}
