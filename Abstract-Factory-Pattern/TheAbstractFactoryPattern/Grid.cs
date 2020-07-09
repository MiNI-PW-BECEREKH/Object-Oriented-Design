using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlatform.Interfaces;

namespace MultiPlatform.Products
{
    public class iOSGrid : IGrid
    {

        public iOSGrid()
        {
            Console.WriteLine($"{nameof(iOSGrid)} is created");
        }

        private List<IButton> buttons = new List<IButton>();
        private List<ITextBox> textBoxes = new List<ITextBox>();
        public void AddButton(IButton button)
        {
            buttons.Add(button);
        }

        public void AddTextBox(ITextBox textBox)
        {
            textBoxes.Add(textBox);
        }

        public IEnumerable<IButton> GetButtons()
        {
            foreach (var button in buttons)
               yield return button;
        }

        public IEnumerable<ITextBox> GetTextBoxes()
        {
            foreach (var textBox in textBoxes)
                yield return textBox;
        }
    }

    public class windowsGrid : IGrid
    {
        public windowsGrid()
        {
            Console.WriteLine($"{nameof(windowsGrid)} is created");
        }

        private List<IButton> buttons = new List<IButton>();
        private List<ITextBox> textBoxes = new List<ITextBox>();
        public void AddButton(IButton button)
        {
            buttons.Add(button);
        }

        public void AddTextBox(ITextBox textBox)
        {
            textBoxes.Add(textBox);
        }

        public IEnumerable<IButton> GetButtons()
        {
            for (int i = buttons.Count - 1; i >= 0; i--)
            {
                yield return buttons[i];
            }
        }

        public IEnumerable<ITextBox> GetTextBoxes()
        {
            yield return textBoxes[0];
            for (int i = textBoxes.Count - 1; i >= 1; i--)
            {
                yield return textBoxes[i];
            }
        }
    }

    public class androidGrid : IGrid
    {
        public androidGrid()
        {
            Console.WriteLine($"{nameof(androidGrid)} is created");
        }

        private List<IButton> buttons = new List<IButton>();
        private List<ITextBox> textBoxes = new List<ITextBox>();
        public void AddButton(IButton button)
        {
            buttons.Add(button);
        }

        public void AddTextBox(ITextBox textBox)
        {
            textBoxes.Add(textBox);
        }

        public IEnumerable<IButton> GetButtons()
        {
            foreach (var button in buttons)
                yield return button;
        }

        public IEnumerable<ITextBox> GetTextBoxes()
        {
            return Enumerable.Empty<ITextBox>();
        }
    }



}
