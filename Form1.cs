namespace PhysicsCalculator
{
    public partial class Form1 : Form
    {
        static double g = 9.81;
        double num1, num2, result;
        static Dictionary<string, PhysicsVariable> PhysicsVariablePointer = new Dictionary<string, PhysicsVariable>();

        public class PhysicsVariable
        {
            public PhysicsVariable(string type, Dictionary<string, double> units, string label1, string label2, Func<double, double, double>formula)
            {
                Type = type;
                Units = units;
                Label1 = label1;
                Label2 = label2;
                Formula = formula;
                PhysicsVariablePointer.Add(Type, this);
            }
            public string Type;
            public Dictionary<string, double> Units;
            public string Label1;
            public string Label2;
            public Func<double, double, double> Formula;
        }

        PhysicsVariable F = new PhysicsVariable("F", new Dictionary<string, double>() { { "N", 1 } }, "m (kg)", "a (m/s2)", (m, a) => m * a);
        PhysicsVariable p = new PhysicsVariable("p", new Dictionary<string, double>() { { "Pa", 1 } }, "F (N)", "s (m2)", (F, s) => F / s);
        PhysicsVariable A = new PhysicsVariable("P", new Dictionary<string, double>() { { "J", 1 }, { "cal", 1 / 4.18 } }, "F (N)", "s (m)", (F, s) => F * s);
        PhysicsVariable P = new PhysicsVariable("A", new Dictionary<string, double>() { { "W", 1 } }, "A (J)", "t (s)", (A, t) => A / t);
        PhysicsVariable Ep = new PhysicsVariable("Ep", new Dictionary<string, double>() { { "J", 1 }, { "cal", 1 / 4.18 } }, "m (kg)", "h (m)", (m, h) => m * g * h);
        PhysicsVariable Ek = new PhysicsVariable("Ek", new Dictionary<string, double>() { { "J", 1 }, { "cal", 1 / 4.18 } }, "m (kg)", "v (m/s)", (m, v) => (m * Math.Pow(v, 2)) / 2);

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

            comboBox1.Items.Clear();
            foreach (var item in PhysicsVariablePointer) comboBox1.Items.Add(item.Value.Type);
            comboBox1.SelectedItem = comboBox1.Items[0];

            comboBox2.Items.Clear();
            foreach(var unit in PhysicsVariablePointer[comboBox1.Items[0].ToString()].Units) comboBox2.Items.Add(unit.Key);
            comboBox2.SelectedItem = comboBox2.Items[0];

            setLabels(PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Label1,
                      PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Label2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setLabels(PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Label1,
                      PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Label2);

            comboBox2.Items.Clear();
            foreach (var unit in PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Units) comboBox2.Items.Add(unit.Key);
            comboBox2.SelectedItem = comboBox2.Items[0];

            Calculate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e){ Calculate(); }
        private void textBox1_TextChanged(object sender, EventArgs e){ Calculate(); }
        private void textBox2_TextChanged(object sender, EventArgs e){ Calculate(); }

        void setLabels(string label1, string label2)
        {
            typeLabel1.Text = label1;
            typeLabel2.Text = label2;
        }

        void Calculate()
        {
            bool canParseNum1 = double.TryParse(textBox1.Text, out num1);
            bool canParseNum2 = double.TryParse(textBox2.Text, out num2);

            if (!canParseNum1 || !canParseNum2) return;

            result = PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Formula(num1, num2);
            result = result * PhysicsVariablePointer[comboBox1.SelectedItem.ToString()].Units[comboBox2.SelectedItem.ToString()];
            resultLabel.Text = Simplify(result).ToString() + comboBox2.SelectedItem.ToString();
        }

        string Simplify(double num)
        {
            string prefix = "";
            int exponent = (int)Math.Floor(Math.Log(num, 1000));

            try { prefix = Prefixes[exponent]; }
            catch 
            {
                if (exponent > 5)
                {
                    exponent = 5;
                    prefix = "P";
                }
                else if (exponent < -3)
                {
                    exponent = -3;
                    prefix = "n";
                }
            }
            return Math.Round(num / Math.Pow(1000, exponent), 3).ToString() + prefix;
        }
    }
}