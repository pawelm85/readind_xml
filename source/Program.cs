using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WyszukiwanieXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputXmlSingle =
           @"
<mieszkania>
<mieszkanie id='1'>
   <miasto>Miasto</miasto>
   <adres>Ulica 100</adres>
   <kod>00-000</kod>
      <pokoj>
         <typ>kuchnia</typ>
         <pow>12</pow>
      </pokoj>
      <pokoj>
         <typ>sypialnia</typ>
         <pow>15</pow>
      </pokoj>
      <pokoj>
         <typ>sypialnia</typ>
         <pow>12</pow>
      </pokoj>
   </mieszkanie>
</mieszkania>
  ";

            string inputXmlMulti =
                @"<mieszkania>
<mieszkanie id='1'>
   <miasto>Miasto</miasto>
   <adres>Ulica 100</adres>
   <kod>00-000</kod>
      <pokoj>
         <typ>kuchnia</typ>
         <pow>12</pow>
      </pokoj>
      <pokoj>
         <typ>sypialnia</typ>
         <pow>15</pow>
      </pokoj>
      <pokoj>
         <typ>sypialnia</typ>
         <pow>12</pow>
      </pokoj>
   </mieszkanie>
<mieszkanie id='2'>
   <miasto>Miasto</miasto>
   <adres>Ulica 100</adres>
   <kod>00-000</kod>
      <pokoj>
         <typ>kuchnia</typ>
         <pow>7</pow>
      </pokoj>
      <pokoj>
         <typ>sypialnia</typ>
         <pow>20</pow>
      </pokoj>
      <pokoj>
         <typ>sypialnia</typ>
         <pow>25</pow>
      </pokoj>
 <pokoj>
         <typ>salon</typ>
         <pow>35</pow>
      </pokoj>
   </mieszkanie>

</mieszkania>
";

            XElement element = XElement.Parse(inputXmlMulti);

            //***********przykład 1*****************
            //var pokoje = from p in element.Descendants("pokoj") select  p.Element("typ").Value;
            //foreach (var pokoj in pokoje)
            //{
            //    Console.WriteLine(pokoj);
            //}

            //***********przykład 2*****************
            //var pokoje = from pokoj in element.Descendants("pokoj") select pokoj;
            var pokoje = element.Descendants("pokoj").Select(p => p);           

            foreach (var pokoj in pokoje)
            {
                //Console.WriteLine(pokoj);
                //Console.WriteLine();
                //Console.WriteLine($"{pokoj.Descendants("mieszkanie").Elements("pokoj")}");
               // Console.WriteLine($"=> {pokoj.Element("typ").Value} powierzchnia: {pokoj.Element("pow").Value}");
            }

            //***********przykład 3*****************
            var mieszkania = element.Descendants("mieszkanie").Select(m=>m);
            foreach(var mieszkanie in mieszkania)
            {
                Console.WriteLine($"=> Mieszkanie ID:{ mieszkanie.Attribute("id").Value}");
                foreach (var pokoj in mieszkanie.Descendants("pokoj").Select(p => p))
                {
                    Console.WriteLine($"===>{pokoj.Element("typ").Value} powierzchnia: {pokoj.Element("pow").Value}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
