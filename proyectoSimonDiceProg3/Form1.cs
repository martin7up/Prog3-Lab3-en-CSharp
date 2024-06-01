namespace proyectoSimonDiceProg3
{
    public partial class Form1 : Form
    {
        //Constructor
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();//Objeto aleatorio p/ aux y aux1
            botones = new Button[4];
            botones[0] = btSuperior;
            botones[1] = btDerecho;
            botones[2] = btInferior;
            botones[3] = btIzquierdo;
            btSuperior.Enabled = btDerecho.Enabled = btInferior.Enabled = btIzquierdo.Enabled = false;
        }
        //Eventos de Click en Botones y de Intervalos en Timers
        private void btComenzar_Click(object sender, EventArgs e)
        {
            if (ingresando)
            {
                btSuperior.Enabled = btDerecho.Enabled = btInferior.Enabled = btIzquierdo.Enabled = false;
                btComenzar.Enabled = false;
                MessageBox.Show(esGanador()? "Felicitaciones! Ingreso la secuencia correcta!" : "...Desafortunadamente no ingreso la secuencia correcta...");
                contador = 0;// Reinicio del contador.
                ingresando = false;
                btComenzar.Enabled = true;
            }
            else
            {
                btComenzar.Enabled = false;//Evitar un doble clickeo del boton comenzar.
                aux1 = rnd.Next(2, 5);//Se define la longitud de la secuencia de botones a encender y apagar.
                secuenciaGenerada = new Button[aux1];//Instancias para determinar si el jugador acerto o no.
                secuenciIngresada = new Button[aux1];
                timerSecuencia.Start();
            }
        }
        private void timerSecuencia_Tick(object sender, EventArgs e)//En este evento, si no finalizo la secuencia, se enciende el boton que corresponda.
        {
            timerSecuencia.Stop();
            if (contador == aux1)//Se verifica si se alcanzo el numero generado de secuencia
            {
                MessageBox.Show($"...una aiuda, la secuencia es de {contador} botones en total.");
                btSuperior.Enabled = btDerecho.Enabled = btInferior.Enabled = btIzquierdo.Enabled = true;
                btComenzar.Enabled = true;
                ingresando = true;
                MessageBox.Show("Ingresa ahora la secuencia que hayas memorizado; cuando hayas terminado presiona el boton central; exito!");
                borrarEsteMetodo();// ----------------->>>   ¡ESTO ES HACER TRAMPAS!
                return;
            }
            aux = rnd.Next(0, 4);//Seleccion aleatoria de alguno de los botones, cuyas referencias estan en el arreglo Button[]...
            colorAux = botones[aux].BackColor;//Se guarda el color del boton seleccionado(aleatoriamente) para, luego de encenderlo, poder apagarlo.
            secuenciaGenerada[contador] = botones[aux];//Se graba la secuencia de botones que se genero.         
            botones[aux].BackColor = encenderColor(botones[aux]);
            contador++;//Se cuenta la secuencia ejecutada
            timerApagado.Start();
        }
        private void timerApagado_Tick(object sender, EventArgs e)
        {
            timerApagado.Stop();
            botones[aux].BackColor = colorAux;//Aqui se produce el apagado del boton en cuestion.
            if(!ingresando) timerSecuencia.Start();
        }
        private void btSuperior_Click(object sender, EventArgs e)
        {
            reaccionarAlPresionarBoton(0, btSuperior);
            ingresarUnBotonDesdeUsuario(btSuperior);
        }
        private void btDerecho_Click(object sender, EventArgs e)
        {
            reaccionarAlPresionarBoton(1, btDerecho);
            ingresarUnBotonDesdeUsuario(btDerecho);
        }
        private void btInferior_Click(object sender, EventArgs e)
        {
            reaccionarAlPresionarBoton(2, btInferior);
            ingresarUnBotonDesdeUsuario(btInferior);
        }
        private void btIzquierdo_Click(object sender, EventArgs e)
        {
            reaccionarAlPresionarBoton(3, btIzquierdo);
            ingresarUnBotonDesdeUsuario(btIzquierdo);
        }
        //Metodos de funcionalidad
        private bool esGanador()
        {
            for (int i = 0; i < aux1; i++)
                if (secuenciaGenerada[i] != secuenciIngresada[i]) return false;
            return true;
        }
        private Color encenderColor(Button button)
        {
            if (button.BackColor == Color.ForestGreen) return Color.Lime;
            if (button.BackColor == Color.DarkBlue) return Color.Blue;
            if (button.BackColor == Color.DarkRed) return Color.Red;
            if (button.BackColor == Color.Gold) return Color.Yellow;
            return Color.White;//Esto esta aqui, en teoria, solo por exigencia del compilador, nunca deberia de retornarse este Color.
        }
        private void borrarEsteMetodo()//Te dice la secuencia de colores correcta.
        {
            string str = "";
            foreach (Button item in secuenciaGenerada)
            {
                str += item.BackColor.Name + "\n";
            }
            MessageBox.Show(str);
        }
        private void ingresarUnBotonDesdeUsuario(Button button)
        {
            if (contador < 1)//En caso de que el usuario ingrese mas botones de los que debe para ganar.
                secuenciIngresada[aux1 - 1] = button;//Esto puede producir que gane aun ingresando mas botones de los que debe, si el ultimo ingresado es igual al ultimo mostrado en la secuencia generada.
            else
                secuenciIngresada[aux1 - contador] = button;
            contador--;
        }
        private void reaccionarAlPresionarBoton(int posicEnArray, Button button)
        {
            aux = posicEnArray;// A ser utilizado en el evento de timerApagado.
            colorAux = button.BackColor;
            button.BackColor = encenderColor(button);
            timerApagado.Start();
        }
    }
}