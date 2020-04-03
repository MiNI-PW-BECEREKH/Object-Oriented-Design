using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlatform.Interfaces;
using MultiPlatform.concreteFactories;

namespace MultiPlatform
{
	class Program
	{
		private static void BuildUI(IGUIFactory platform) //... type of platform
		{
            IGrid grid = platform.createGrid();
            //create 3 buttons
            IButton button1 = platform.createButton();
            IButton button2 = platform.createButton();
            IButton button3 = platform.createButton();
            //set the contents
            button1.Content = "BigPurpleButton";
            button2.Content = "SmallButton";
            button3.Content = "Baton";
            //add buttons to the grid
            grid.AddButton(button1);
            grid.AddButton(button2);
            grid.AddButton(button3);
            //create 3 textboxes
            ITextBox textBox1 = platform.createTextBox();
            ITextBox textBox2 = platform.createTextBox();
            ITextBox textBox3 = platform.createTextBox();
            //set the contents
            textBox1.Content = "";
            textBox2.Content = "EmptyTextBox";
            textBox3.Content = "xoBtxeT";
            //add textboxes to the grid;
            grid.AddTextBox(textBox1);
            grid.AddTextBox(textBox2);
            grid.AddTextBox(textBox3);


            foreach(var button in grid.GetButtons())
            {
                button.ButtonPressed();
                button.DrawContent();
            }

            foreach(ITextBox textBox in grid.GetTextBoxes())
            {
                textBox.DrawContent();
            }
        }

		static void Main(string[] args)
		{

			Console.WriteLine("<---------------------iOS--------------------->");
            iOSFactory iOS = new iOSFactory();
            BuildUI(iOS);

			Console.WriteLine("<---------------------Windows--------------------->");
            WindowsFactory windows = new WindowsFactory();
            BuildUI(windows);
			

			Console.WriteLine("<---------------------Android--------------------->");
            AndroidFactory android = new AndroidFactory();
            BuildUI(android);
			
		}
	}
}
