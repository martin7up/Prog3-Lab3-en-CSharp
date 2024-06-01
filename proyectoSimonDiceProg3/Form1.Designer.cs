namespace proyectoSimonDiceProg3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btSuperior = new Button();
            btIzquierdo = new Button();
            btDerecho = new Button();
            btInferior = new Button();
            btComenzar = new Button();
            timerSecuencia = new System.Windows.Forms.Timer(components);
            timerApagado = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btSuperior
            // 
            btSuperior.BackColor = Color.ForestGreen;
            btSuperior.Location = new Point(220, 5);
            btSuperior.Name = "btSuperior";
            btSuperior.Size = new Size(215, 199);
            btSuperior.TabIndex = 0;
            btSuperior.UseVisualStyleBackColor = false;
            btSuperior.Click += btSuperior_Click;
            // 
            // btIzquierdo
            // 
            btIzquierdo.BackColor = Color.Gold;
            btIzquierdo.Location = new Point(6, 210);
            btIzquierdo.Name = "btIzquierdo";
            btIzquierdo.Size = new Size(215, 199);
            btIzquierdo.TabIndex = 1;
            btIzquierdo.UseVisualStyleBackColor = false;
            btIzquierdo.Click += btIzquierdo_Click;
            // 
            // btDerecho
            // 
            btDerecho.BackColor = Color.DarkRed;
            btDerecho.Location = new Point(433, 210);
            btDerecho.Name = "btDerecho";
            btDerecho.Size = new Size(215, 199);
            btDerecho.TabIndex = 2;
            btDerecho.UseVisualStyleBackColor = false;
            btDerecho.Click += btDerecho_Click;
            // 
            // btInferior
            // 
            btInferior.BackColor = Color.DarkBlue;
            btInferior.Location = new Point(220, 415);
            btInferior.Name = "btInferior";
            btInferior.Size = new Size(215, 199);
            btInferior.TabIndex = 3;
            btInferior.UseVisualStyleBackColor = false;
            btInferior.Click += btInferior_Click;
            // 
            // btComenzar
            // 
            btComenzar.BackColor = Color.FromArgb(64, 64, 64);
            btComenzar.Location = new Point(227, 210);
            btComenzar.Name = "btComenzar";
            btComenzar.Size = new Size(200, 199);
            btComenzar.TabIndex = 4;
            btComenzar.UseVisualStyleBackColor = false;
            btComenzar.Click += btComenzar_Click;
            // 
            // timerSecuencia
            // 
            timerSecuencia.Interval = 1000;
            timerSecuencia.Tick += timerSecuencia_Tick;
            // 
            // timerApagado
            // 
            timerApagado.Interval = 300;
            timerApagado.Tick += timerApagado_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(653, 618);
            Controls.Add(btComenzar);
            Controls.Add(btInferior);
            Controls.Add(btDerecho);
            Controls.Add(btIzquierdo);
            Controls.Add(btSuperior);
            Name = "Form1";
            Text = "Simon Rrrree ATR";
            ResumeLayout(false);
        }

        #endregion

        private Button btSuperior;
        private Button btIzquierdo;
        private Button btDerecho;
        private Button btInferior;
        private Button btComenzar;
        private System.Windows.Forms.Timer timerSecuencia;
        private System.Windows.Forms.Timer timerApagado;
        //Agregados manualmente
        bool ingresando;
        private Random rnd;
        private Color colorAux;
        private Button[] botones;
        private Button[] secuenciaGenerada;
        private Button[] secuenciIngresada;
        private int aux, aux1, contador;
    }
}
