namespace proyAgendaContactos_LabComp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (Persona persona in Program.personas)
                comboBox1.Items.Add(persona);
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //label1.Text = comboBox1.SelectedItem.ToString() is null? "<Sin seleccionar aun.>" : comboBox1.SelectedItem.ToString();
            if (comboBox1.SelectedItem is null) return;
            Persona persona = comboBox1.SelectedItem as Persona;
            dataGridView1.Rows.Add(persona);
            //dataGridView1.Rows.Insert(dataGridView1.Rows.Count, persona.NombreCompleto, persona.Id, persona.Creacion.ToString("F(es-Ar)"));
        }
    }
}
