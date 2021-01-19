using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using ClassLibrary;

namespace ConsoleApp
{
    class ValidXML
    {
        static bool errflag = false;

        private static void ValidationHandler(object sender, ValidationEventArgs args)
        {

            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine($"Warning: {args.Message}");
            else
            {
                errflag = true;
                Console.WriteLine($"Error: {args.Message}");
                //OR
                //throw new System.Exception(.....) ??
                
            }
        }

        static void Main(string[] args)
        {

            

            XmlReaderSettings settings = new XmlReaderSettings();
            // Validator settings
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

            // Here we add xsd files to namespaces we want to validate
            // (It's like XML -> Schemas setting in Visual Studio)
            settings.Schemas.Add("http://example.org/jk/library", @"C:\Users\suhey\OneDrive\Masaüstü\semester4_repos\OOD\XMLtutorial\ClassLibrary\ClassLibrary\LibraryNamedTypes.xsd");

            // Processing XSI Schema Location attribute
            // (Disabled by default as it is a security risk). 
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;

            // A function delegate that will be called when 
            // validation error or warning occurs
            settings.ValidationEventHandler += ValidationHandler;

            XmlReader reader = XmlReader.Create(@"../../../../Library.xml", settings);

            // Read method reads next element or attribute from the document
            // It will call ValidationEventHandler if some invalid
            // part occurs
            while (reader.Read())
            {


            }
            reader.Close();


            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Library.library lib = LibraryReader.ReadLibrary();
            if(errflag != true)
                foreach(var book in lib.book.ToArray())
                {
                    foreach (var author in book.author.ToArray())
                        foreach (var a in lib.author)
                            if (a.authorid == author.authorref1)
                                Console.WriteLine($"{a.surname}");
                }


            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
