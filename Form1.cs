using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RPS_IUT
{
    public partial class Form1 : Form
    { 
        List<string>courseArray = new List<string>();
        List<double>TotalArray = new List<double>();
        List<double> gpaArray=new List<double>();
        List<string>gradeArray=new List<string>();
        public Form1()
        {
            InitializeComponent();
            resultlistBox.Items.Add("Course Code \t Marks \t Grade \t GPA");
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < gpaArray.Count; i++)
            {
                string R = $"{courseArray[i]} \t {TotalArray[i]} \t {gradeArray[i]} \t{gpaArray[i]}";
                resultlistBox.Items.Add(R);
            }

            double sum = 0;
            for(int j=0;j<gpaArray.Count;j++)
            {
                sum = sum+ gpaArray[j];
            }
            double CGPA = sum / gpaArray.Count;
            cgpalabel.Text=Convert.ToString(CGPA);
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            nametextBox.Clear();
            idtextBox.Clear();
            midtextBox.Clear();
            quiz1textBox.Clear();
            quiz2textBox.Clear();
            quiz3textBox.Clear();
            quiz4textBox.Clear();
            semestertextBox.Clear();
            attendencetextBox.Clear();

            nametextBox.Focus();
        }

        private void removebutton_Click(object sender, EventArgs e)
        {
            resultlistBox.Items.Remove(resultlistBox.Items[resultlistBox.Items.Count - 1]);
        }

        private void cgpalabel_Click(object sender, EventArgs e)
        {
            
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            string name = nametextBox.Text;
            string id = idtextBox.Text;
            string course = coursecomboBox.Text;
            courseArray.Add(course);
            int mid = Convert.ToInt32(midtextBox.Text);
            int quiz1 = Convert.ToInt32(quiz1textBox.Text);
            int quiz2 = Convert.ToInt32(quiz2textBox.Text);
            int quiz3 = Convert.ToInt32(quiz3textBox.Text);
            int quiz4 = Convert.ToInt32(quiz4textBox.Text);
            int semester = Convert.ToInt32(semestertextBox.Text);
            int attendence = Convert.ToInt32(attendencetextBox.Text);

            int[] quiz = new int[4];
            quiz[0] = quiz1;
            quiz[1] = quiz2;
            quiz[2] = quiz3;
            quiz[3] = quiz4;

            Array.Sort(quiz);

            int Quiz = (quiz[1] + quiz[2] + quiz[3]);

            double res = (mid + Quiz + attendence + semester) / 3;
            TotalArray.Add(res);

            string grade = "";
            double GPA = 0;

            if (res <= 100 && res >= 80)
            {
                grade = "A+";
                GPA = 4;
            }
            else if (res >= 75 && res < 80)
            {
                grade = "A";
                GPA = 3.75;
            }
            else if (res >= 70 && res < 75)
            {
                grade = "A-";
                GPA = 3.50;
            }
            else if (res >= 65 && res < 70)
            {
                grade = "B+";
                GPA = 3.25;
            }
            else if (res >= 60 && res < 65)
            {
                grade = "B";
                GPA = 3.00;
            }
            else if (res >= 55 && res < 60)
            {
                grade = "B-";
                GPA = 2.75;
            }
            else if (res >= 50 && res < 55)
            {
                grade = "C+";
                GPA = 2.50;
            }
            else if (res >= 45 && res < 50)
            {
                grade = "C";
                GPA = 2.25;
            }
            else if (res >= 40 && res < 45)
            {
                grade = "D";
                GPA = 2.00;
            }
            else
            {
                grade = "F";
                GPA = 0;
            }

            gpaArray.Add(GPA);
            gradeArray.Add(grade);

            midtextBox.Clear();
            quiz1textBox.Clear();
            quiz2textBox.Clear();
            quiz3textBox.Clear();
            quiz4textBox.Clear();
            semestertextBox.Clear();
            attendencetextBox.Clear();

            midtextBox.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
