using System;
using System.Linq;
using System.Xml.Linq;

namespace WyszukiwanieXML
{
    class Program
    {
        static void Main(string[] args)
        {
            #region xml - pojedyncze mieszkanie
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
            #endregion


            #region xml - więcej mieszkań
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
            #endregion



            XElement element = XElement.Parse(inputXmlMulti);

            //  Przykład 1 - pobieranie tylko wartości typ dla każdego pokoju
            //var pokoje = from p in element.Descendants("pokoj") select  p.Element("typ").Value;
            //foreach (var pokoj in pokoje)
            //{
            //    Console.WriteLine(pokoj);
            //}

            // Przykład 2 - pobieranie dla każdego pokoju wartości typ i wartości pow
            //var pokoje = from pokoj in element.Descendants("pokoj") select pokoj;
            //var pokoje = element.Descendants("pokoj").Select(p => p);           

            //foreach (var pokoj in pokoje)
            //{
                //Console.WriteLine(pokoj);
                //Console.WriteLine();
                //Console.WriteLine($"{pokoj.Descendants("mieszkanie").Elements("pokoj")}");
               // Console.WriteLine($"=> {pokoj.Element("typ").Value} powierzchnia: {pokoj.Element("pow").Value}");
            //}

            // Przykład 3 - pobieranie id mieszkania i typ oraz pow poszczególnych pokoi
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
