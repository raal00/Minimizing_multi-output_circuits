using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace КупсачАвтоматы
{
    public class TextBoxIO
    {
        public void WriteFunctionsToTextBox(RichTextBox textBox, List<Boolfunction> functions)
        {
            int i = 0;
            textBox.Text = "";
            foreach (var function in functions)
            {
                i++;

                foreach (var value in function.values)
                {
                    textBox.Text += value.ToString() + " ";
                }
                textBox.Text += '\n';
            }
        }

        public void printResult(RichTextBox textBox, List<BoolfunctionWithMinterms> bfunctions, int MaxArguments, int argumentsInMinterm)
        {
            int funcNumber = 0;
            int mintermNumber = 0;
            List<string> printedMinterms = new List<string>();
            if (bfunctions != null)
            {
                foreach (var func in bfunctions)
                {
                    mintermNumber = 0;
                    funcNumber++;
                    textBox.Text += funcNumber.ToString() + " function: ";
                    foreach (var mint in func.minterms)
                    {
                        mintermNumber++;
                        string MintermString = GetStringByMinterm(mint, MaxArguments, argumentsInMinterm);
                        if (!printedMinterms.Contains(MintermString))
                        {
                            textBox.Text += MintermString;
                            if (func.minterms.Count > mintermNumber) textBox.Text += " v ";
                        }
                        printedMinterms.Add(MintermString);
                    }

                    textBox.Text += '\n';
                }
                textBox.BackColor = Color.LightGreen;
            }
            else
            {
                textBox.BackColor = Color.Red;
            }
        }

        private string GetStringByMinterm(Minterm min, int MaxArguments, int argumentsInMinterm)
        {
            string res = min.A.ToString() + min.B.ToString()
                        + min.C.ToString() + min.D.ToString()
                        + min.E.ToString() + min.F.ToString();
            if (res.Contains("4")) return string.Empty;
            res = res.Replace('3', '-');
            res = res.Substring(MaxArguments - argumentsInMinterm);
            // 000101 3
            return res;
        }
    }
}
