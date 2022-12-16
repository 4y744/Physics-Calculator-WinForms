namespace PhysicsCalculator
{
    public partial class Form1 : Form
    {
        static double g = 9.81;
        double num1, num2, result;

        //Class for physics variables
        //Stores type, units of measurement (+ relative coefficient) and labels (types and units of the variables required by the formula)
         public class PhysicsVariable
        {
            //Constructor - called when object is created
            public PhysicsVariable(string type, Dictionary<string, double> units, string label1, string label2)
            {
                Type = type;
                Units = units;
                Label1 = label1;
                Label2 = label2;
            }
            public string Type;
            public Dictionary<string, double> Units;
            public string Label1;
            public string Label2;
        }

        //Static class with the formulas for each of the physics variables
        //static - doesn't require and object and can be directly called
        static class PhysicsCalculate
        {
            public static double F(double m, double a) { return m * a; } //F = ma
            public static double p(double F, double s) { return F / s; } //p = F/s
            public static double A(double F, double s) { return F * s; } //A = Fs
            public static double P(double A, double t) { return A / t; } //P = A/t
            public static double Ep(double m, double h) { return m * g * h; } //Ep = mgh
            public static double Ek(double m, double v) { return (m * Math.Pow(v,2)) / 2; } //Ek = mv2/2
        }

        //Sets the physics variable objects 
        PhysicsVariable F = new PhysicsVariable("F", new Dictionary<string, double>() { { "N", 1 } }, "m (kg)", "a (m/s2)");
        PhysicsVariable p = new PhysicsVariable("p", new Dictionary<string, double>() { { "Pa", 1 } }, "F (N)", "s (m2)");
        PhysicsVariable A = new PhysicsVariable("P", new Dictionary<string, double>() { { "J", 1 }, { "cal", 1 / 4.18 } }, "F (N)", "s (m)");
        PhysicsVariable P = new PhysicsVariable("A", new Dictionary<string, double>() { { "W", 1 } }, "A (J)", "t (s)");
        PhysicsVariable Ep = new PhysicsVariable("Ep", new Dictionary<string, double>() { { "J", 1 }, { "cal", 1 / 4.18 } }, "m (kg)", "h (m)");
        PhysicsVariable Ek = new PhysicsVariable("Ek", new Dictionary<string, double>() { { "J", 1 }, { "cal", 1 / 4.18 } }, "m (kg)", "v (m/s)");

        //Takes a string as input and returns a PhysicsVariable object
        Dictionary<string, PhysicsVariable> PhysicsVariablePointer = new Dictionary<string, PhysicsVariable>();

        //Takes a string as input and returns a method with 2 doubles as params and double as return
        //The returned method can be called by adding "()" and giving 2 arguments 
        Dictionary<string, Func<double, double, double>> PhysicsCalculatePointer = new Dictionary<string, Func<double, double, double>>();

        //Takes exponent and returns SI unit prefix
        Dictionary<int, string> Prefixes = new Dictionary<int, string>()
        {
            {-3, "n" },
            {-2, "μ" },
            {-1, "m" },
            {0, "" },
            {1, "k" },
            {2, "M" },
            {3, "G" },
            {4, "T" },
            {5, "P" },
        };
        
        public Form1()
        {
            InitializeComponent();

            //Sets up the pointer
            PhysicsVariablePointer = new Dictionary<string, PhysicsVariable>()
            {
                {"F", F },
                {"p", p },
                {"P", P },
                {"A", A },
                {"Ep", Ep },
                {"Ek", Ek }
            };

            //Sets up the pointer
            PhysicsCalculatePointer = new Dictionary<string, Func<double, double, double>>()
            {
                {"F",  PhysicsCalculate.F},
                {"p", PhysicsCalculate.p},
                {"P", PhysicsCalculate.P },
                {"A", PhysicsCalculate.A },
                {"Ep", PhysicsCalculate.Ep },
                {"Ek", PhysicsCalculate.Ek }
            };

            //Adds the comboBox1 items by using the PhysicsVariablePointer to point to every PhysicsVariable object
            //item.Value is the value mapped to the key
            //Sets default selected item for comboBox1
            comboBox1.Items.Clear();
            foreach (var item in PhysicsVariablePointer) comboBox1.Items.Add(item.Value.Type);
            comboBox1.SelectedItem = comboBox1.Items[0];

            //Gets the selected comboBox1 item and adds its units to comboBox2 
            comboBox2.Items.Clear();
            foreach(var unit in PhysicsVariablePointer[comboBox1.Items[0].ToString()].Units) comboBox2.Items.Add(unit.Key);
            comboBox2.SelectedItem = comboBox2.Items[0];

            setLabels(PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Label1,
                      PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Label2);
        }

        ////Called on comboBox1 change
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Changes labels when item is changed for comboBox1
            setLabels(PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Label1,
                      PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Label2);

            comboBox2.Items.Clear();
            foreach (var unit in PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Units) comboBox2.Items.Add(unit.Key);
            comboBox2.SelectedItem = comboBox2.Items[0];

            Calculate();
        }

        //Called on comboBox2 change
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        //Called on textBox1 text change
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        //Called on textBox2 text change
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        //Sets the labels
        void setLabels(string label1, string label2)
        {
            typeLabel1.Text = label1;
            typeLabel2.Text = label2;
        }

        void Calculate()
        {
            //Gets the values of the text boxes
            bool canParseNum1 = double.TryParse(textBox1.Text, out num1);
            bool canParseNum2 = double.TryParse(textBox2.Text, out num2);

            if (!canParseNum1 || !canParseNum2) return;

            //Does the mathematical operations to get a result
            result = PhysicsCalculatePointer[comboBox1.SelectedItem.ToString()](num1, num2);
            result = result * PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Units[comboBox2.SelectedItem.ToString()];
            resultLabel.Text = Simplify(result).ToString() + comboBox2.SelectedItem.ToString();
        
        }

        string Simplify(double num)
        {
            string prefix = "";
            //Simplifies
            //E.g. 10000N -> 10kN
            int exponent = (int)Math.Floor(Math.Log(num, 1000));

            try { prefix = Prefixes[exponent]; }
            catch 
            {
                //We haven't set prefixes for "power" > 5, so we just set it to 5 and let "num" grow to infinity
                if (exponent > 5)
                {
                    exponent = 5;
                    prefix = "P";
                }
                //We haven't set prefixes for "power" < -3, so we just set it to -3 and let "num" shrink to 0
                else if (exponent < -3)
                {
                    exponent = -3;
                    prefix = "n";
                }
            }

           

            //Divides by 1000 to some power and adds the prefix
            //If "num" is < 0, then "power" is negative => num increases
            //This is because x^-n = 1 / x^n => num / 1000^-n = num * 1000^n
            return Math.Round(num / Math.Pow(1000, exponent), 3).ToString() + prefix;
        }
    }
}