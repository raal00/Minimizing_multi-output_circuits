using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace КупсачАвтоматы
{
    public partial class Form1 : Form
    {
        private List<Boolfunction> inputFunctionSystem;
        private List<BoolfunctionWithMinterms> minimizedFunctionSystem;

        public TextBoxIO boxIO;

        private readonly int MaxFunctions;
        private readonly int MaxArgumentsInFunction;
        private readonly int MaxArgumentInFunction;
        private readonly int MinArgumentInFunction;
        private int ArgumentsInMinterm;
        private int MaxArgumentsInMinterm;

        private int functionCount = 0;

        public Form1()
        {
            InitializeComponent();

            boxIO = new TextBoxIO();

            MaxArgumentsInFunction = 10;
            MaxArgumentInFunction = 63;
            MinArgumentInFunction = 0;
            MaxArgumentsInMinterm = 6;
            MaxFunctions = 10;

            functionLabel.Text = "Функция " + functionCount.ToString() + " =";
            inputFunctionSystem = new List<Boolfunction>();
            inputFunctionBox.DoubleClick += FuncBox_DoubleClick;
            this.Shown += Form1_Shown;
        }


        #region Methods
        /// <summary>
        /// remove last function in system
        /// </summary>
        private void removeFunction()
        {
            if (inputFunctionSystem.Count > 0) inputFunctionSystem.RemoveAt(inputFunctionSystem.Count - 1);
        }

        /// <summary>
        /// convert int value to minterm
        /// 5 -> A!B!CD
        /// </summary>
        /// <returns>result or null</returns>
        private List<Minterm> ConvertMinterm(Boolfunction boolfunction)
        {
            List<Minterm> minterms = new List<Minterm>();
            foreach (var value in boolfunction.values)
            {
                Minterm minterm = new Minterm();

                // 0 - 63
                int decValue = value;

                #region Minterm settings
                if (decValue >= 32)
                {
                    decValue -= 32;
                    minterm.A = 1;
                }
                else
                {
                    minterm.A = 0;
                }
                if (decValue >= 16)
                {
                    decValue -= 16;
                    minterm.B = 1;
                }
                else
                {
                    minterm.B = 0;
                }
                if (decValue >= 8)
                {
                    decValue -= 8;
                    minterm.C = 1;
                }
                else
                {
                    minterm.C = 0;
                }
                if (decValue >= 4)
                {
                    decValue -= 4;
                    minterm.D = 1;
                }
                else
                {
                    minterm.D = 0;
                }
                if (decValue >= 2)
                {
                    decValue -= 2;
                    minterm.E = 1;
                }
                else
                {
                    minterm.E = 0;
                }
                if (decValue >= 1)
                {
                    decValue -= 1;
                    minterm.F = 1;
                }
                else
                {
                    minterm.F = 0;
                }
                #endregion
                minterms.Add(minterm);
            }
            return minterms;
        }

        /// <summary>
        /// Find argument for merging
        /// </summary>
        /// <returns>Merging of 2 minterms</returns>
        private Minterm MergeMinterms(Minterm X, Minterm Y)
        {
            int k = 0;
            if (X.A == Y.A) k++;
            if (X.B == Y.B) k++;
            if (X.C == Y.C) k++;
            if (X.D == Y.D) k++;
            if (X.E == Y.E) k++;
            if (X.F == Y.F) k++;
            if (k == 5)
            {
                Minterm result = new Minterm();
                result.Used = true;
                if (X.A != Y.A)
                {
                    result.A = 3;
                    result.B = X.B;
                    result.C = X.C;
                    result.D = X.D;
                    result.E = X.E;
                    result.F = X.F;
                }
                else if (X.B != Y.B)
                {
                    result.B = 3;
                    result.A = X.A;
                    result.C = X.C;
                    result.D = X.D;
                    result.E = X.E;
                    result.F = X.F;
                }
                else if (X.C != Y.C)
                {
                    result.C = 3;
                    result.A = X.A;
                    result.B = X.B;
                    result.D = X.D;
                    result.E = X.E;
                    result.F = X.F;
                }
                else if (X.D != Y.D)
                {
                    result.D = 3;
                    result.A = X.A;
                    result.C = X.C;
                    result.B = X.B;
                    result.E = X.E;
                    result.F = X.F;
                }
                else if (X.E != Y.E)
                {
                    result.E = 3;
                    result.A = X.A;
                    result.C = X.C;
                    result.B = X.B;
                    result.D = X.D;
                    result.F = X.F;
                }
                else if (X.F != Y.F)
                {
                    result.F = 3;
                    result.A = X.A;
                    result.C = X.C;
                    result.B = X.B;
                    result.E = X.E;
                    result.D = X.D;
                }
                return result;
            }
            return null;
        }

        private bool CheckfunctionValidation(Boolfunction function)
        {
            foreach (var value in function.values)
            {
                if (value < MinArgumentInFunction || value > MaxArgumentInFunction) return false;
            }
            return true;
        }

        /// <summary>
        /// Minimize input system
        /// </summary>
        private void Minimization()
        {
            if (inputFunctionSystem == null) throw new Exception("null functions");
            
            foreach (var function in inputFunctionSystem)
            {
                if (!CheckfunctionValidation(function))
                {
                    MessageBox.Show("Значение функции должно находиться в диапазоне");
                    return;
                }
            }

            int MaxArgumentInSystem = 0;
            minimizedFunctionSystem = new List<BoolfunctionWithMinterms>();
            List<BoolfunctionWithMinterms> MintermsSystem = new List<BoolfunctionWithMinterms>();


            foreach (var function in inputFunctionSystem)
            {
                foreach (var val in function.values)
                {
                    if (val > MaxArgumentInSystem) MaxArgumentInSystem = val;
                }
                BoolfunctionWithMinterms BFunction = new BoolfunctionWithMinterms();
                BFunction.minterms = ConvertMinterm(function);
                MintermsSystem.Add(BFunction);
            }

            int number = 0;
            if (MaxArgumentInSystem >= 32) ArgumentsInMinterm = 6;
            else if (MaxArgumentInSystem >= 16 && MaxArgumentInSystem < 32) ArgumentsInMinterm = 5;
            else if (MaxArgumentInSystem >= 8 && MaxArgumentInSystem < 16) ArgumentsInMinterm = 4;
            else if (MaxArgumentInSystem >= 4 && MaxArgumentInSystem < 8) ArgumentsInMinterm = 3;
            else if (MaxArgumentInSystem >= 2 && MaxArgumentInSystem < 4) ArgumentsInMinterm = 2;
            else ArgumentsInMinterm = 1;

            // MERGING
            bool IsMerged;

            // Проход по каждой функции
            foreach (var functionM in MintermsSystem)
            {
                BoolfunctionWithMinterms minF = new BoolfunctionWithMinterms();
                minF.minterms = new List<Minterm>();
                do
                {
                    IsMerged = false;
                    number = 0;
                    List<Minterm> ForDeliting = new List<Minterm>();
                    List<Minterm> ForAdding = new List<Minterm>();

                    foreach (var minterm in functionM.minterms)
                    {
                        number++;
                        foreach (var nextMinterm in functionM.minterms.GetRange(number, functionM.minterms.Count - number))
                        {
                            Minterm res = MergeMinterms(minterm, nextMinterm);
                            if (res != null)
                            {
                                IsMerged = true;
                                ForAdding.Add(res);
                                ForDeliting.Add(minterm);
                                ForDeliting.Add(nextMinterm);
                            }
                        }
                    }

                    foreach (var delMinterm in ForDeliting)
                    {
                        functionM.minterms.Remove(delMinterm);
                    }
                    foreach (var addMinterm in ForAdding)
                    {
                        functionM.minterms.Add(addMinterm);
                    }
                    foreach (var minterm in functionM.minterms)
                    {
                        if (minterm.Used == false)
                        { 
                            minF.minterms.Add(minterm);
                        }
                    }
                    ForDeliting.Clear();
                    ForAdding.Clear();
                    functionM.minterms.RemoveAll(x => x.Used == false);
                    foreach (var minterm in functionM.minterms)
                    {
                        minterm.Used = false;
                    }
                }
                while (IsMerged);
                minimizedFunctionSystem.Add(minF);
            }
            boxIO.printResult(resTB, minimizedFunctionSystem, MaxArgumentsInMinterm, ArgumentsInMinterm);
        }
        #endregion

        #region Events
        private void Form1_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Привет! Эта программа поможет тебе\n" +
                 "минимизировать систему булевых функций\n" +
                 "Вводи через запятую значения от 0 до 63 в окно ввода\n" +
                 "Затем нажми кнопку <минимизировать систему>");
        }
        private void FuncBox_DoubleClick(object sender, EventArgs e)
        {
            if (inputFunctionSystem.Count >= MaxFunctions)
            {
                MessageBox.Show("Достигнуто макс. число функций");
                return;
            }
            functionCount++;
            functionLabel.Text = "Функция " + functionCount.ToString() + " =";
            string res = inputFunctionBox.Text;
            Boolfunction function = new Boolfunction();

            try
            {
                function.values = res.Split(',').Select(int.Parse).ToList();
            }
            catch (Exception err)
            {
                inputFunctionBox.BackColor = Color.Red;
                MessageBox.Show("Ошибка во входных данных " + err.Message);
                return;
            }

            inputFunctionBox.BackColor = Color.LightGreen;
            if (function.values.Count > MaxArgumentsInFunction)
            {
                function.values.RemoveRange(MaxArgumentsInFunction, function.values.Count - MaxArgumentsInFunction);
            }
            inputFunctionSystem.Add(function);
            boxIO.WriteFunctionsToTextBox(functionText, inputFunctionSystem);
            inputFunctionBox.Text = "";
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            Minimization();
        }
        private void resClearbtn_Click(object sender, EventArgs e)
        {
            resTB.Text = "";
        }
        private void deleteFunctionBtn_Click(object sender, EventArgs e)
        {
            removeFunction();
            boxIO.WriteFunctionsToTextBox(functionText, inputFunctionSystem);
        }
        #endregion
    }
}
