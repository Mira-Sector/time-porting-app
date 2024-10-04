using System.Data;
using System.Linq;
using TimePort.models;


namespace TimePort
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
           

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBoxNickname.Text;
            string path = "C:/Users/tomas/AppData/Roaming/Space Station 14/data/roles/" + textBoxNickname.Text + ".cfg";

            StreamWriter writer = new StreamWriter(path);

            List<Label> roles = GetAllControls(this).OfType<Label>().ToList();
            roles = roles.Where(item => !item.Name.Contains("Cosmetic")).ToList();
            int timeOverall = 0;
            foreach (Label role in roles)
                
            {
                string pain = "textBoxH" + role.Name.Substring(5);
                int roleHoursInMinutes = Int32.Parse(GetTextBoxByName("textBoxH" + role.Name.Substring(5)).Text) * 60;
                int roleMinutes = Int32.Parse(GetTextBoxByName("textBoxM" + role.Name.Substring(5)).Text);
                if (roleHoursInMinutes >= 0 && roleMinutes >= 0)
                {
                    writer.Write("playtime_addrole " +
                    userName + " Job" + role.Name.Substring(5) + " " +
                    (roleHoursInMinutes + roleMinutes) + "\n");
                    timeOverall += roleHoursInMinutes + roleMinutes;
                }


            }
            writer.Write("playtime_addoverall " + textBoxNickname.Text + " " + timeOverall+"\n");
            writer.Write("playtime_save " + textBoxNickname.Text);
            writer.Flush();
            writer.Close();
        }

        private Boolean playTimeAboveZero(TextBox minutes)
        {
            if (Int64.Parse(minutes.Text) > 0)
            {
                return true;
            }
            return false;
        }

        public static IEnumerable<Control> GetAllControls(Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);

            while (stack.Any())
            {
                var next = stack.Pop();
                foreach (Control child in next.Controls)
                    stack.Push(child);

                yield return next;
            }
        }

        private TextBox GetTextBoxByName(string name)
        {
            // Use the Controls.Find method to search for the control by name
            Control[] controls = this.Controls.Find(name, true);

            if (controls.Length > 0 && controls[0] is TextBox)
            {
                return (TextBox)controls[0];
            }

            return null;
        }
    }
}
