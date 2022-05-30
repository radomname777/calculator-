namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool start = true;
        bool clickbutton = false;
        int numiter = 0;
        string operators = "";
        private void one_Click(object sender, EventArgs e)
        {


            if (sender is Button button)

            {
                if (txt_label.Text=="0")
                {
                    if (button.Text!="00") txt_label.Text = button.Text;
                    return;
                }
                else if (button.Text == "," &&txt_label.Text.Contains(",") )  return;
                if (clickbutton)
                {
                    txt_label.Text = "0";
                    clickbutton = false;
                }
                txt_label.Text += button.Text;

            }
            
        }
        double[] num = new double[2];
        private double Check(string oper,double num,double num2){
            switch (oper)
            {
                case "+":return num + num2;
                case "-": return num - num2;
                case "X": return num * num2;
                case "÷": return num / num2;
                case "²": return num2 * num2;
            }
            return num2;
        }
        string opea = "";
        bool trueorfalse = false;
        double numbers = 0;
        int numberi = 2;
        private void Clear_Click(object sender, EventArgs e)
        {

            numiter++;
            if (sender is Button button)
            {

                if (button.Text == "=" && txt_label.Text == "0") return;
      
                if (start)num[0] = Convert.ToDouble(txt_label.Text);
                
                if(!trueorfalse)num[1] = Convert.ToDouble(txt_label.Text);
                

                switch (button.Text)
                {
                    case "c":
                        start = true;
                        numberi = 2; label2.Text = "";
                        numiter = 0; txt_label.Text = "0";
                        return;

                    case "R":
                        txt_label.Text = txt_label.Text.Remove(txt_label.Text.Length-1);
                        if (txt_label.Text.Length==0) txt_label.Text = "0";
                        return;
                    case "+":
                        label2.Text = "+" + num[0];

                        numbers = Check("+", num[0], num[1]);

                        trueorfalse = true;
                        break;
                    case "-":
                        if (!start) numbers = Check("-", num[0], num[1]);
                        else { numbers = num[0]; };
                        label2.Text = num[0] + "-";
                        trueorfalse = true;
                        break;
                    case "÷":
                        if (!start)
                        {
                            numbers = Check("÷", num[0], num[1]);
                        }
                        else { numbers = num[0]; };
                        label2.Text = num[0] + "÷";
                        trueorfalse = true;
                        break;
                    case "X":
                        if (!start){ numbers = Check("X", num[0], num[1]); }
                        else { numbers = num[0]; };
                        label2.Text = num[0] + "X";
                        trueorfalse = true;
                        break;
                    case "²":
                        if (start) numberi = 1;
                        numbers = Check("²", num[1], num[0]);num[0] = numbers;
                        // MessageBox.Show(numbers.ToString());
                          label2.Text = num[0].ToString();

                        trueorfalse = true;
                        break;
                    case "=":
                            label2.Text = $"{num[0]} {opea} {num[1]} =";
                            if (!start)
                            {
                                numbers = Check(opea, num[0], num[1]);
                                if(opea!= "²") num[0] = numbers;
                            }
                            txt_label.Text = num[0].ToString();
                            trueorfalse = true;

                        return;
                    default:
                        break;
                }
                if (!start&&opea!= "²") numbers = Check(opea, num[0], num[1]);
                opea = button.Text;
                if (trueorfalse)
                {
                    trueorfalse = false;
                    txt_label.Text = "0";
                }
                if (numiter >= numberi)
                {
                    numberi = 1;
                    numiter = 0;
                    num[0] = numbers;
                   label2.Text = numbers.ToString();
                }
                start = false;
            }
        }
    }
}